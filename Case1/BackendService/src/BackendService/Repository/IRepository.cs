using BackendService.Entities;
using System.Collections.Generic;

namespace BackendService.Repository
{
    public interface IRepository<T, K>
    {

        IEnumerable<T> FindAll();
        T FindBy(K id);
        void Insert(T item);
    }

}