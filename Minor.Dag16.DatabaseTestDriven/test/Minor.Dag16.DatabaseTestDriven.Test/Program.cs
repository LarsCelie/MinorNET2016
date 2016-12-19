using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag16.DatabaseTestDriven.Test
{
    [TestClass]
    public class Program
    {
        private static DbContextOptions<BoogContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<BoogContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }


        [TestMethod]
        public void AddNewBow()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var target = new BoogRepository(options);

            Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };
            // Act
            target.Insert(boog);

            // Assert
            using (var context = new BoogContext(options))
            {
                Assert.IsTrue(context.Bogen.Any(b => b.Merk == "Hoyt"));
            } 
        }

        [TestMethod]
        public void AddNewBowWithCategory()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var target = new BoogRepository(options);

            Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };
            // Act
            target.Insert(boog);

            // Assert
            using (var context = new BoogContext(options))
            {
                Assert.IsTrue(context.Bogen.Any(b => b.Categorie.Naam == "Recurve"));
            }
        }

        [TestMethod]
        public void FindBow()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var target = new BoogRepository(options);

            Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };

            target.Insert(boog);

            // Act
            var collection = target.FindAll();

            // Assert
            Assert.AreEqual(1, collection.Count());
        }

        [TestMethod]
        public void FindBowWithCategory()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var target = new BoogRepository(options);

            Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };

            target.Insert(boog);

            // Act
            var collection = target.FindAll();

            // Assert
            Assert.AreEqual("Recurve", collection.First().Categorie.Naam);
        }

        [TestMethod]
        public void FindBowWithCategoryByFilter()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var target = new BoogRepository(options);

            Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };

            target.Insert(boog);

            // Act
            var collection = target.FindBy(b => b.Merk == "Hoyt");

            // Assert
            Assert.AreEqual(1, collection.Count());
            Assert.AreEqual("Recurve", collection.First().Categorie.Naam);
        }

        [TestMethod]
        public void AddMultipleBowsWithSameCategory()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var target = new BoogRepository(options);

            Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };
            Boog boog2 = new Boog { Merk = "Kaas", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };

            target.Insert(boog);
            target.Insert(boog2);

            // Act
            var collection = target.FindAll().Where(b => b.Categorie.Naam == "Recurve");

            // Assert
            Assert.AreEqual(2, collection.Count());
        }

        [TestMethod]
        public void FindBowById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var target = new BoogRepository(options);

            Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };
            Boog boog2 = new Boog { Merk = "Kaas", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };

            target.Insert(boog);
            target.Insert(boog2);

            // Act
            var b = target.FindById(1);

            // Assert
            Assert.AreEqual("Hoyt", b.Merk);
        }

        [TestMethod]
        public void DeleteBow()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var target = new BoogRepository(options);

            Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };
            Boog boog2 = new Boog { Merk = "Kaas", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };
            Boog boog3 = new Boog { Merk = "Gert", Prijs = 765.00M, Rechtshandig = true, Lengte = 27, Categorie = cat };

            target.Insert(boog);
            target.Insert(boog2);
            target.Insert(boog3);

            // Act
            target.Delete(boog2);

            // Assert
            using (var context = new BoogContext(options))
            {
                bool result = context.Bogen.Any(b => b.Merk == "Kaas");
                Assert.IsFalse(result);
            }
        }
    }
}
