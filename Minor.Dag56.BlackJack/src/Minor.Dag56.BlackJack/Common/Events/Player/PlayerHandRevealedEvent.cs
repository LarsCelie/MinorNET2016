using Minor.Dag56.BlackJack.Domain;
using Minor.WSA.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Common.Events
{
    public class PlayerHandRevealedEvent : DomainEvent
    {
        public Card[] Cards { get; set; }

        public PlayerHandRevealedEvent(Card[] cards)
        {
            Cards = cards;
        }
    }
}
