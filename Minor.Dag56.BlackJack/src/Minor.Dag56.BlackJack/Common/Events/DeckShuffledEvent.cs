using Minor.WSA.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag56.BlackJack.Common.Events
{
    public class DeckShuffledEvent : DomainEvent
    {
        public int Seed { get; set; }

        public DeckShuffledEvent(int seed)
        {
            Seed = seed;
        }

    }
}
