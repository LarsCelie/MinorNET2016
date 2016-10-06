using System;
using System.Linq;
using System.Collections.Generic;
using Minor.Dag19.WebApi.DAL;
using Minor.Dag19.WebApi.Entities;

namespace Minor.Dag19.WebApi.Mock
{
    public class MonumentRepositoryMockOrDummyOrPerhapsStub : IRepository<Monument, int>
    {
        private List<Monument> monumenten;
        public bool FindAllHasBeenCalled { get; private set; }
        public bool FindIdHasBeenCalled { get; private set; }
        public Monument InsertParameter { get; private set; }
        public bool InsertHasBeenCalled { get; private set; }
        public bool UpdateHasBeenCalled { get; private set; }
        public Monument UpdateParameter { get; private set; }
        public bool DeleteHasBeenCalled { get; private set; }
        public int DeleteId { get; private set; }

        public MonumentRepositoryMockOrDummyOrPerhapsStub()
        {
            monumenten = new List<Monument> { new Monument { Id = 1, Naam="Eiffeltoren", Hoogte=300},
                                        new Monument { Id = 2, Naam="Toren van Pisa", Hoogte=56},
                                        new Monument { Id = 3, Naam="Empire State Building", Hoogte=381}
                                        };
        }

        public IEnumerable<Monument> FindAll()
        {
            FindAllHasBeenCalled = true;
            return monumenten;
        }

        public Monument Find(int id)
        {
            FindIdHasBeenCalled = true;
            return monumenten.Single(m => m.Id == id);
        }

        public void Insert(Monument mon)
        {
            InsertHasBeenCalled = true;
            InsertParameter = mon;

        }

        public void Update(Monument monument)
        {
            UpdateHasBeenCalled = true;
            UpdateParameter = monument;
        }

        public void Delete(int id)
        {
            DeleteHasBeenCalled = true;
            DeleteId = id;
        }
    }
}