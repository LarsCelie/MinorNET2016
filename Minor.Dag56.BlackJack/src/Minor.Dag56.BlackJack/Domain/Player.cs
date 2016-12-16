using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Domain
{
    public class Player
    {

        private Hand _hand;

        public Player()
        {
            _hand = new Hand();
        }

        internal void GiveCard(Card card)
        {
            _hand.AddCard(card);
        }

        internal Card[] Cards()
        {
            return _hand.Cards();
        }

        internal int HandValue()
        {
            return _hand.GetValue();
        }
    }
}