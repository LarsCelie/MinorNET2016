using Minor.Dag56.BlackJack.Common.Events;
using Minor.Dag56.BlackJack.Domain;
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
            Init();
            Shuffle();
            DealPlayerCard();
            DealPlayerCard();
            DealDealerCard();
            DealDealerCard();
        }

        public void Init()
        {
            var gameEvent = new GameStartedEvent();
            _publisher.Publish(gameEvent);

            _game = new Game();

            _game.Execute(gameEvent);
        }

        public void Shuffle()
        {
            int seed = new Random().Next();
            var gameEvent = new DeckShuffledEvent(seed);

            _game.Execute(gameEvent);
        }

        public void DealPlayerCard()
        {
            var card = _game.NewCard();
            var gameEvent = new CardDealtEvent(card);
        }


        private void DealDealerCard()
        {
            throw new NotImplementedException();
        }


        public Game RestoreGame()
        {
            var game = new Game();
            foreach (var gameEvent in _repository.All())
            {
                game.Execute(gameEvent as dynamic);
            }
            return game;
        }
    }
}
