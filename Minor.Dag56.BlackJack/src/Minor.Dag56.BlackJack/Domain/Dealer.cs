using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public class Dealer
    {
        private Deck _deck;
        private Hand _hand;

        public Dealer()
        {
            _deck = new Deck();
            _hand = new Hand();
        }

        internal Card DrawCard()
        {
            return _deck.DealCard();
        }

        internal void Shuffle(int seed)
        {
            _deck.Shuffle(seed);
        }

        internal void GiveCard(Card card)
        {
            _hand.AddCard(card);
        }

        internal int HandValue()
        {
            return _hand.GetValue();
        }

        internal Card[] Cards()
        {
            return _hand.Cards();
        }
    }
}