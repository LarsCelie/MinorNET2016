using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public class Deck
    {
        private static int NumberOfDecks = 8;
        private List<Card> cards;
        public Deck()
        {
            for (int i = 0; i < NumberOfDecks; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    {
                        cards.Add(new Card(suit, rank));
                    }
                }
            }
        }



        public Card DealCard()
        {
            var card = cards[0];
            cards.Remove(card);
            return card;
        }

        public void Shuffle(int seed)
        {
            var rng = new Random(seed);
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
