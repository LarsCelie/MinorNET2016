using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public class Deck
    {
        private static int NumberOfDecks = 8;
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
            for (int i = 0; i < NumberOfDecks; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    {
                        _cards.Add(new Card(suit, rank));
                    }
                }
            }
        }

        public Card DealCard()
        {
            var card = _cards[0];
            _cards.Remove(card);
            return card;
        }

        public void Shuffle(int seed)
        {
            var rng = new Random(seed);
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }
    }
}
