using Minor.Dag56.BlackJack.Common.Events;
using Minor.Dag56.BlackJack.Domain;
using Minor.WSA.Common.Events;
using Minor.WSA.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.DomainService
{
    public class GameService : IGameService
    {
        private IRepository _repository;
        private IEventPublisher _publisher;
        private Game _game;

        public GameService(IRepository repository, IEventPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public void StartGame()
        {
            RestoreGame();
            InitGame();
            ShuffleDeck();
            DealPlayerCard();
            DealPlayerHiddenCard();
            DealDealerCard();
            DealDealerHiddenCard();

            CheckForBlackJack();

            //Testing purposes
            _game = null;
        }

        private void RestoreGame()
        {
            _game = new Game();
            foreach (var gameEvent in _repository.All())
            {
                _game.Execute(gameEvent as dynamic);
            }
        }

        private void InitGame()
        {
            var gameEvent = new GameStartedEvent();
            _publisher.Publish(gameEvent);
            _repository.Add(gameEvent);

            _game = new Game();

            _game.Execute(gameEvent);
        }

        private void ShuffleDeck()
        {
            int seed = new Random().Next();
            var gameEvent = new DeckShuffledEvent(seed);
            _publisher.Publish(gameEvent);
            _repository.Add(gameEvent);

            _game.Execute(gameEvent);
        }

        private void DealPlayerCard()
        {
            var card = _game.DrawNewCard();
            _game.DealCardToPlayer(card);

            var gameEvent = new PlayerCardDealtEvent(card);
            _publisher.Publish(gameEvent);
            _repository.Add(gameEvent);
        }

        private void DealPlayerHiddenCard()
        {
            var card = _game.DrawNewCard();
            _game.DealCardToPlayer(card);

            var gameEvent = new PlayerHiddenCardDealtEvent(card);
            _publisher.Publish(gameEvent);
            _repository.Add(gameEvent);
        }


        private void DealDealerCard()
        {
            var card = _game.DrawNewCard();
            _game.DealCardToDealer(card);

            var gameEvent = new DealerCardDealtEvent(card);
            _publisher.Publish(gameEvent);
            _repository.Add(gameEvent);
        }

        private void DealDealerHiddenCard()
        {
            var card = _game.DrawNewCard();
            _game.DealCardToDealer(card);

            var gameEvent = new DealerHiddenCardDealtEvent();
            process(gameEvent);
        }

        private void CheckForBlackJack()
        {
            var playerPoints = _game.PlayerHandValue();
            if (playerPoints == 21)
            {
                var gameEvent = new PlayerBlackJackEvent();
                process(gameEvent);

                int dealerPoints = _game.DealerHandValue();
                if (dealerPoints == 21)
                {
                    var dealerEvent = new DealerBlackJackEvent();
                    process(dealerEvent);

                    PlayerPush();
                }
                else
                {
                    PlayerWin();
                }
            }
        }

        public void Hit()
        {
            RestoreGame();
            if (!_game.InProgress)
            {
                throw new InvalidOperationException();
            }            

            var card = _game.DrawNewCard();
            _game.DealCardToPlayer(card);

            var gameEvent = new PlayerHitsEvent(card);
            process(gameEvent);

            int playerPoints = _game.PlayerHandValue();
            if (playerPoints > 21)
            {
                var bustEvent = new PlayerBustsEvent(playerPoints);
                process(bustEvent);
                PlayerLose();
            }

            //Testing purposes
            _game = null;
        }

        public void Stand()
        {
            RestoreGame();

            if (!_game.InProgress)
            {
                throw new InvalidOperationException();
            }
            
            CalculatePlayerHand();
            PlayDealerHand();
            DetermineWinner();

            //Testing purposes
            _game = null;
        }

        private void CalculatePlayerHand()
        {
            int points = _game.PlayerHandValue();
            var gameEvent = new PlayerStandsEvent(points);
            process(gameEvent);
        }

        private void PlayDealerHand()
        {
            int dealerPoints = _game.DealerHandValue();
            if (dealerPoints == 21)
            {
                var gameEvent = new DealerBlackJackEvent();
                process(gameEvent);
                return;
            }
            while (dealerPoints < 17)
            {
                var card = _game.DrawNewCard();
                _game.DealCardToDealer(card);
                var gameEvent = new DealerHitsEvent(card);
                process(gameEvent);

                dealerPoints = _game.DealerHandValue();
            }
            if (dealerPoints <= 21)
            {
                var gameEvent = new DealerStandsEvent(dealerPoints);
                process(gameEvent);
            }
        }

        private void DetermineWinner()
        {
            var playerPoints = _game.PlayerHandValue();
            var dealerPoints = _game.DealerHandValue();

            if (dealerPoints > 21)
            {
                var gameEvent = new DealerBustsEvent(dealerPoints);
                process(gameEvent);

                PlayerWin();
            }
            else if (playerPoints > dealerPoints)
            {
                PlayerWin();
            }
            else if (playerPoints < dealerPoints)
            {
                PlayerLose();
            }
            else
            {
                PlayerPush();
            }
        }

        private void PlayerWin()
        {
            var playerCards = _game.PlayerHand();
            var playerHandValue = _game.PlayerHandValue();

            var dealerCards = _game.DealerHand();
            var dealerHandValue = _game.DealerHandValue();

            var gameEvent = new PlayerWinsEvent(playerCards, playerHandValue, dealerCards, dealerHandValue);
            process(gameEvent);

            GameFinished();
        }

        private void PlayerLose()
        {
            var playerCards = _game.PlayerHand();
            var playerHandValue = _game.PlayerHandValue();

            var dealerCards = _game.DealerHand();
            var dealerHandValue = _game.DealerHandValue();

            var gameEvent = new PlayerLostEvent(playerCards, playerHandValue, dealerCards, dealerHandValue);
            process(gameEvent);

            GameFinished();
        }

        private void PlayerPush()
        {
            var playerCards = _game.PlayerHand();
            var playerHandValue = _game.PlayerHandValue();

            var dealerCards = _game.DealerHand();
            var dealerHandValue = _game.DealerHandValue();

            var gameEvent = new PlayerPushEvent(playerCards, playerHandValue, dealerCards, dealerHandValue);
            process(gameEvent);

            GameFinished();
        }

        private void GameFinished()
        {
            var gameEvent = new GameFinishedEvent();
            process(gameEvent);

            _game.InProgress = false;
        }

        public void ShowPlayerHand()
        {
            RestoreGame();
            Card[] cards = _game.PlayerHand();
            var gameEvent = new PlayerHandRevealedEvent(cards);
            process(gameEvent);

            //Testing purposes
            _game = null;
        }

        public void RestartGame()
        {
            RestoreGame();

            var gameEvent = new GameRestartedEvent();
            process(gameEvent);

            _game.Execute(gameEvent);

            StartGame();

            //Testing purposes
            _game = null;
        }

        private void process(DomainEvent gameEvent)
        {
            _publisher.Publish(gameEvent);
            _repository.Add(gameEvent);
        }
    }
}
