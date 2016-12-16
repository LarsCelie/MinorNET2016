using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public class Hand
    {
        private List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }

        internal void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public int GetValue()
        {
            int handWorth = _cards.Sum(c => c.GetValue());

            if (handWorth > 21)
            {
                foreach (var card in _cards)
                {
                    if (card.Rank == Rank.Ace)
                    {
                        handWorth -= 10;
                        if (handWorth <= 21)
                        {
                            return handWorth;
                        }
                    }
                }
            }
            return handWorth;
        }

        internal Card[] Cards()
        {
            return _cards.ToArray();
        }
    }
}