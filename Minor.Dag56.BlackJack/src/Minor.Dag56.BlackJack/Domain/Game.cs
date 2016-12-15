using Minor.Dag56.BlackJack.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public class Game
    {
        public Deck Deck { get; set; }


        public Game()
        {
            Deck = new Deck();
        }

        public Card NewCard()
        {
            return Deck.DealCard();
        }

        public void Execute(GameStartedEvent gameEvent)
        {
            // nothing to do.
        }

        public void Execute(CardDealtEvent gameEvent)
        {
            NewCard();
        }

        public void Execute(DeckShuffledEvent gameEvent)
        {
            int seed = gameEvent.Seed;
            Deck.Shuffle(gameEvent.Seed);
        }
    }
}
