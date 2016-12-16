using Minor.Dag56.BlackJack.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public class Game
    {
        public bool InProgress { get; set; }

        private Dealer _dealer;
        private Player _player;

        public Game()
        {
            _dealer = new Dealer();
            _player = new Player();
            InProgress = true;
        }

        public Card DrawNewCard()
        {
            if (!InProgress)
            {
                throw new InvalidOperationException();
            }
            return _dealer.DrawCard();
        }

        internal Card[] PlayerHand()
        {
            return _player.Cards();
        }

        internal Card[] DealerHand()
        {
            return _dealer.Cards();
        }

        internal int PlayerHandValue()
        {
            return _player.HandValue();
        }

        internal int DealerHandValue()
        {
            return _dealer.HandValue();
        }

        internal void DealCardToPlayer(Card card)
        {
            if (!InProgress)
            {
                throw new InvalidOperationException();
            }
            _player.GiveCard(card);
        }

        internal void DealCardToDealer(Card card)
        {
            if (!InProgress)
            {
                throw new InvalidOperationException();
            }
            _dealer.GiveCard(card);
        }

        public void Execute(GameStartedEvent gameEvent)
        {
            // nothing to do
        }

        public void Execute(GameRestartedEvent gameEvent)
        {
            _dealer = new Dealer();
            _player = new Player();
            InProgress = true;
        }

        public void Execute(GameFinishedEvent gameEvent)
        {
            InProgress = false;
        }

        public void Execute(DeckShuffledEvent gameEvent)
        {
            _dealer.Shuffle(gameEvent.Seed);
        }

        public void Execute(PlayerCardDealtEvent gameEvent)
        {
            var card = _dealer.DrawCard();
            _player.GiveCard(card);
        }

        public void Execute(DealerCardDealtEvent gameEvent)
        {
            var card = _dealer.DrawCard();
            _dealer.GiveCard(card);
        }

        public void Execute(PlayerHiddenCardDealtEvent gameEvent)
        {
            var card = _dealer.DrawCard();
            _player.GiveCard(card);
        }

        public void Execute(DealerHiddenCardDealtEvent gameEvent)
        {
            var card = _dealer.DrawCard();
            _dealer.GiveCard(card);
        }

        public void Execute(PlayerHandRevealedEvent gameEvent)
        {
            // No need to do anything, but for consistency calling the method.
            PlayerHand();
        }

        public void Execute(PlayerHitsEvent gameEvent)
        {
            var card = _dealer.DrawCard();
            _player.GiveCard(card);
        }

        public void Execute(DealerHitsEvent gameEvent)
        {
            var card = _dealer.DrawCard();
            _dealer.GiveCard(card);
        }

        public void Execute(PlayerStandsEvent gameEvent)
        {
            // Do nothing
        }

        public void Execute(DealerStandsEvent gameEvent)
        {
            // Do nothing
        }

        public void Execute(PlayerBustsEvent gameEvent)
        {
            // Do nothing
        }

        public void Execute(DealerBustsEvent gameEvent)
        {
            // Do nothing
        }

        public void Execute(PlayerWinsEvent gameEvent)
        {
            // Do nothing
        }

        public void Execute(PlayerLostEvent gameEvent)
        {
            // Do nothing
        }

        public void Execute(PlayerPushEvent gameEvent)
        {
            // Do nothing
        }

        public void Execute(PlayerBlackJackEvent gameEvent)
        {

        }

        public void Execute(DealerBlackJackEvent gameEvent)
        {

        }


    }
}
