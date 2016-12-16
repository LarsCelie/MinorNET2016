using Minor.WSA.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.Dag56.BlackJack.Domain;

namespace Minor.Dag56.BlackJack.Common.Events
{
    public class PlayerHiddenCardDealtEvent : DomainEvent
    {
        public Card Card { get; set; }

        public PlayerHiddenCardDealtEvent(Card card)
        {
            Card = card;
        }
    }
}
