using BackendService.Controllers;
using BackendService.Dummy;
using BackendService.Entities;
using BackendService.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Test
{
    [TestClass]
    public class CursusControllerTest
    {

        [TestMethod]
        public void GetAll()
        {
            CursusRepositoryDummy repo = new CursusRepositoryDummy();
            var target = new CursusController(repo);

            IEnumerable<CursusInstantie> result = target.Get();
            
            Assert.IsTrue(repo.FindAllIsCalled);
        }

        [TestMethod]
        public void GetById()
        {
            CursusRepositoryDummy repo = new CursusRepositoryDummy();
            var target = new CursusController(repo);

            CursusInstantie result = target.Get(1);
            Assert.IsTrue(repo.FindByIdIsCalled);
            Assert.IsNotNull(result);
            Assert.AreEqual("ABC", result.Cursus.Code);
        }

        [TestMethod]
        public void GetByIdIsInvalid()
        {
            CursusRepositoryDummy repo = new CursusRepositoryDummy();
            var target = new CursusController(repo);

            Assert.ThrowsException<InvalidOperationException>(() => target.Get(9));
        }

        [TestMethod]
        public void Insert()
        {
            // Arrange
            CursusRepositoryDummy repo = new CursusRepositoryDummy();
            var target = new CursusController(repo);

            // Act
            var cursus = new CursusInstantie { Cursus = new Cursus { Code = "ABC", Titel = "Test", Duur = 2 }, Startdatum = DateTime.Today.ToString(), Id = 1 };
            target.Post(new List<CursusInstantie> { cursus });

            // Assert
            Assert.IsTrue(repo.InsertIsCalled);
            Assert.AreEqual("ABC", repo.CreateParameter.Cursus.Code);
        }
    }
}
