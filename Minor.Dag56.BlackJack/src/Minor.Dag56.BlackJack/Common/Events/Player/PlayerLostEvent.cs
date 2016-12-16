using Minor.WSA.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.Dag56.BlackJack.Domain;

namespace Minor.Dag56.BlackJack.Common.Events
{
    public class PlayerLostEvent : DomainEvent
    {
        public Card[] DealerCards { get; set; }
        public int DealerHandValue { get; set; }
        public Card[] PlayerCards { get; set; }
        public int PlayerHandValue { get; set; }

        public PlayerLostEvent(Card[] playerCards, int playerHandValue, Card[] dealerCards, int dealerHandValue)
        {
            PlayerCards = playerCards;
            PlayerHandValue = playerHandValue;
            DealerCards = dealerCards;
            DealerHandValue = dealerHandValue;
        }
    }
}
