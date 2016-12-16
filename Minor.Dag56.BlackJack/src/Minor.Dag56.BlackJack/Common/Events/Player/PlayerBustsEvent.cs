using Minor.WSA.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Common.Events
{
    public class PlayerBustsEvent : DomainEvent
    {
        public int HandWorthInPoints { get; set; }

        public PlayerBustsEvent(int points)
        {
            HandWorthInPoints = points;
        }
    }
}
