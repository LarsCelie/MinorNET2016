using Minor.WSA.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.Dag56.BlackJack.Domain;

namespace Minor.Dag56.BlackJack.Common.Events
{
    public class CardDealtEvent : DomainEvent
    {
        public Card Card { get; set; }

        public CardDealtEvent(Card card)
        {
            Card = card;
        }
    }
}
