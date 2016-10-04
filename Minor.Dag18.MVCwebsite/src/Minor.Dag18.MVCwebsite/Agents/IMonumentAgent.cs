using Minor.Dag18.MVCwebsite.Entities;
using System.Collections.Generic;

namespace Minor.Dag18.MVCwebsite.Agents
{
    public interface IMonumentAgent
    {
        IEnumerable<Monument> FindAll();

        void Insert(Monument monument);
        void Delete(int id);
    }



}