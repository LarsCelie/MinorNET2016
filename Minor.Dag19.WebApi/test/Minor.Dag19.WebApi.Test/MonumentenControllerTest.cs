using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag19.WebApi.Controllers;
using Minor.Dag19.WebApi.Entities;
using Minor.Dag19.WebApi.Mock;
using System.Collections.Generic;
using System.Linq;

namespace Minor.Dag19.WebApi.Test
{
    [TestClass]
    public class MonumentenControllerTest
    {
        [TestMethod]
        public void GetMonumenten()
        {
            // Arrange
            MonumentRepositoryMockOrDummyOrPerhapsStub repo = new MonumentRepositoryMockOrDummyOrPerhapsStub();
            MonumentenController mc = new MonumentenController(repo);

            var monumenten = new List<Monument> { new Monument { Id = 1, Naam="Eiffeltoren", Hoogte=300},
                                        new Monument { Id = 2, Naam="Toren van Pisa", Hoogte=56},
                                        new Monument { Id = 3, Naam="Empire State Building", Hoogte=381}
                                        };

            // Act
            var result = mc.Get().ToList();

            // Assert
            Assert.IsTrue(repo.FindAllHasBeenCalled);
            CollectionAssert.AreEqual(monumenten, result);
        }

        [TestMethod]
        public void GetMonument()
        {
            // Arrange
            MonumentRepositoryMockOrDummyOrPerhapsStub repo = new MonumentRepositoryMockOrDummyOrPerhapsStub();
            MonumentenController mc = new MonumentenController(repo);

            var monument = new Monument
            {
                Id = 2,
                Naam = "Toren van Pisa",
                Hoogte = 56
            };

            // Act
            var result = mc.Get(2);

            // Assert
            Assert.IsTrue(repo.FindIdHasBeenCalled);
            Assert.AreEqual(monument, result);
        }

        [TestMethod]
        public void AddMonument()
        {
            // Arrange
            MonumentRepositoryMockOrDummyOrPerhapsStub repo = new MonumentRepositoryMockOrDummyOrPerhapsStub();
            MonumentenController mc = new MonumentenController(repo);

            var monument = new Monument
            {
                Id = 4,
                Naam = "Arc de Triompf",
                Hoogte = 16
            };

            // Act
            mc.Post(monument);

            // Assert
            Assert.IsTrue(repo.InsertHasBeenCalled);
            Assert.AreEqual(monument, repo.InsertParameter);
        }

        [TestMethod]
        public void UpdateMonument()
        {
            // Arrange
            MonumentRepositoryMockOrDummyOrPerhapsStub repo = new MonumentRepositoryMockOrDummyOrPerhapsStub();
            MonumentenController mc = new MonumentenController(repo);

            var monument = new Monument
            {
                Id = 3,
                Naam = "Empire State Tower",
                Hoogte = 387
            };

            // Act
            mc.Put(monument.Id, monument);

            // Assert
            Assert.IsTrue(repo.UpdateHasBeenCalled);
            Assert.AreEqual(monument, repo.UpdateParameter);
        }

        [TestMethod]
        public void DeleteMonument()
        {
            // Arrange
            MonumentRepositoryMockOrDummyOrPerhapsStub repo = new MonumentRepositoryMockOrDummyOrPerhapsStub();
            MonumentenController mc = new MonumentenController(repo);

            // Act
            mc.Delete(2);

            // Assert
            Assert.IsTrue(repo.DeleteHasBeenCalled);
            Assert.AreEqual(2, repo.DeleteId);
        }
    }
}
