using BackendService.Entities;
using BackendService.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Test
{
    [TestClass]
    public class RepositoryTest
    {
        private static DbContextOptions<CursusContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<CursusContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [TestMethod]
        public void AddNewCursusInstantie()
        {
            // Arrange
            var options = CreateNewContextOptions();
            IRepository<CursusInstantie, int>  target = new CursusRepository(options);

            Cursus cursus = new Cursus { Code = "ABC", Titel = "The beginning of the alphabet",Duur = 5 };
            CursusInstantie instance = new CursusInstantie { Cursus = cursus, Startdatum = DateTime.Today.ToString() };
            // Act
            target.Insert(instance);

            // Assert
            using (var context = new CursusContext(options))
            {
                Assert.IsTrue(context.CursusInstanties.Any(b => b.Cursus.Code == "ABC"));
            }
        }

        [TestMethod]
        public void AddTwoCursusInstantieWithSameCursus()
        {
            // Arrange
            var options = CreateNewContextOptions();
            IRepository<CursusInstantie, int> target = new CursusRepository(options);

            Cursus cursus = new Cursus { Code = "ABC", Titel = "The beginning of the alphabet", Duur = 5 };
            CursusInstantie instance = new CursusInstantie { Cursus = cursus, Startdatum = DateTime.Today.ToString() };

            CursusInstantie instance2 = new CursusInstantie { Cursus = cursus, Startdatum = DateTime.Today.ToString() };

            target.Insert(instance);
            target.Insert(instance2);

            // Act
            var collection = target.FindAll();

            // Assert
            Assert.AreEqual(2, collection.Count());
            using (var context = new CursusContext(options))
            {
                Assert.AreEqual(1, context.Cursussen.Count());
            }
        }

        [TestMethod]
        public void FindCursusById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            IRepository<CursusInstantie, int> target = new CursusRepository(options);

            Cursus cursus = new Cursus { Code = "ABC", Titel = "The beginning of the alphabet", Duur = 5 };
            CursusInstantie instance = new CursusInstantie { Cursus = cursus, Startdatum = DateTime.Today.ToString() };

            target.Insert(instance);

            // Act
            var item = target.FindById(1);

            // Assert
            Assert.AreEqual(1, item.Id);
            Assert.AreEqual("ABC", item.Cursus.Code);
        }

    }
}
