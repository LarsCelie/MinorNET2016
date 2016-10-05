using System.Collections.Generic;
using Minor.Dag19.WebApi.Entities;

namespace Minor.Dag19.WebApi.DAL
{
    public interface IRepository<T1, T2>
    {
        IEnumerable<Monument> FindAll();
        Monument Find(int id);
        void Insert(Monument mon);
        void Update(Monument monument);
        void Delete(int id);
    }

}