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
            
            // Categorie cat = new Categorie { Naam = "Recurve" };
            Boog boog = new Boog { Merk = "Hoyt", Prijs = 765.00M, Rechtshandig = true, Lengte = 27 };
            // Act
            target.Add(boog);

            // Assert
            using (var context = new BoogContext(options))
            {
                Assert.IsTrue(context.Bogen.Any(b => b.Merk == "Hoyt"));
            } 
        }
    }
}
