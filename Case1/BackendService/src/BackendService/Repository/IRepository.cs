using BackendService.Entities;
using System.Collections.Generic;

namespace BackendService.Repository
{
    public interface IRepository<T, K>
    {

        IEnumerable<T> FindAll();
        void Insert(T item);
        T FindById(K key);
    }

}