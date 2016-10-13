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
            CursusInstantie instance = new CursusInstantie { Cursus = cursus, Startdatum = "11/10/2016" };
            CursusInstantie instance2 = new CursusInstantie { Cursus = cursus, Startdatum = "10/10/2016" };

            // Act
            target.Insert(instance);
            target.Insert(instance2);

            // Assert
            using (var context = new CursusContext(options))
            {
                Assert.AreEqual(2, context.CursusInstanties.Count());
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

        [TestMethod]
        public void AddTwoDuplicateCursusInstantie()
        {
            // Arrange
            var options = CreateNewContextOptions();
            IRepository<CursusInstantie, int> target = new CursusRepository(options);

            Cursus cursus = new Cursus { Code = "ABC", Titel = "The beginning of the alphabet", Duur = 5 };
            CursusInstantie instance = new CursusInstantie { Cursus = cursus, Startdatum = "11/10/2016" };

            target.Insert(instance);

            // Act Assert
            Assert.ThrowsException<DuplicateItemException>(() => target.Insert(instance));
        }

        [TestMethod]
        public void BUG_AddMultipleCursusInstantiesWithSameDatesButDifferentCursusDoesNotSave()
        {
            // Arrange
            var options = CreateNewContextOptions();
            IRepository<CursusInstantie, int> target = new CursusRepository(options);

            Cursus cursus = new Cursus { Code = "CNETIN", Titel = "C# Programmeren", Duur = 5 };
            Cursus cursus2 = new Cursus { Code = "ADCSB", Titel = "Advanced C#", Duur = 2 };
            CursusInstantie instance = new CursusInstantie { Cursus = cursus, Startdatum = "13/10/2016" };
            CursusInstantie instance2 = new CursusInstantie { Cursus = cursus, Startdatum = "20/10/2016" };
            CursusInstantie instance3 = new CursusInstantie { Cursus = cursus2, Startdatum = "20/10/2016" };
            CursusInstantie instance4 = new CursusInstantie { Cursus = cursus2, Startdatum = "13/10/2016" };

            // Act
            target.Insert(instance);
            target.Insert(instance2);
            target.Insert(instance3);
            target.Insert(instance4);

            // Assert
            target.FindAll();

            using (var context = new CursusContext(options))
            {
                Assert.AreEqual(4, context.CursusInstanties.Count());
            }
            
        }

    }
}
