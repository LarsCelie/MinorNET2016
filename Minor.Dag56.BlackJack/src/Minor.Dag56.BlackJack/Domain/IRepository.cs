using Minor.WSA.Common.Events;
using System.Collections.Generic;

namespace Minor.Dag56.BlackJack.Domain
{
    public interface IRepository
    {
        void Add(DomainEvent domainEvent);

        DomainEvent[] All();
    }
}