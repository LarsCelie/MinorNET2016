using System;
using System.Linq;
using System.Collections.Generic;
using Minor.Dag18.MVCwebsite.Agents;
using Minor.Dag18.MVCwebsite.Entities;

namespace Minor.Dag18.MVCwebsite.Agents
{

    public class MonumentAgentDummy : IMonumentAgent
    {
        private List<Monument> _monumenten;
        public MonumentAgentDummy()
        {
            _monumenten = new List<Monument> { new Monument { Id = 1, Naam="Eiffeltoren", Hoogte=300},
                                        new Monument { Id = 2, Naam="Toren van Pisa", Hoogte=56},
                                        new Monument { Id = 3, Naam="Empire State Building", Hoogte=381}
                                        };
        }

        public void Delete(int id)
        {
            Monument monumentToRemove = Find(id);
            _monumenten.Remove(monumentToRemove);
        }

        private Monument Find(int id)
        {
            return _monumenten.SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Monument> FindAll()
        {
            return _monumenten;
        }

        public void Insert(Monument monument)
        {
            throw new NotImplementedException();
        }
    }

}