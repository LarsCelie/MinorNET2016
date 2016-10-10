using System;
using BackendService.Repository;
using System.Linq;
using System.Collections.Generic;
using BackendService.Entities;

namespace BackendService.Dummy
{
    public class CursusRepositoryDummy : IRepository<CursusInstantie, int>
    {
        private List<CursusInstantie> _cursussen;
        public CursusRepositoryDummy()
        {
            _cursussen = new List<CursusInstantie>();
            _cursussen.Add(new CursusInstantie { Id = 1, Cursus = new Cursus { Code = "ABC", Titel = "Test", Duur = 2 }, Startdatum = DateTime.Today });
            _cursussen.Add(new CursusInstantie { Id = 2, Cursus = new Cursus { Code = "CNETIN", Titel = "C# programmeren", Duur = 5 }, Startdatum = DateTime.Today });
            _cursussen.Add(new CursusInstantie { Id = 3, Cursus = new Cursus { Code = "XYZ", Titel = "The end of alphabet", Duur = 3 }, Startdatum = DateTime.Today });
        }

        public bool InsertIsCalled { get; set; }
        public CursusInstantie CreateParameter { get; set; }
        public bool FindAllIsCalled { get; set; }
        public bool FindByIdIsCalled { get; set; }

        public IEnumerable<CursusInstantie> FindAll()
        {
            FindAllIsCalled = true;
            return _cursussen;
        }

        public CursusInstantie FindBy(int id)
        {
            FindByIdIsCalled = true;
            return _cursussen.Single(cursusinstantie => cursusinstantie.Id == id);
        }

        public void Insert(CursusInstantie cursus)
        {
            CreateParameter = cursus;
            InsertIsCalled = true;
        }
    }

}