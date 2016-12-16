using Minor.Dag56.BlackJack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.WSA.Common.Events;
using System.Collections.Concurrent;

namespace Minor.Dag56.BlackJack.Infastructure
{

    public class GameEventRepository : IRepository
    {
        private List<DomainEvent> _events;

        public GameEventRepository()
        {
            _events = new List<DomainEvent>();
        }

        public void Add(DomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public DomainEvent[] All()
        {
            return _events.ToArray();
        }
    }
}
