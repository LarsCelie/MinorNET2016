using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag16.DatabaseTestDriven
{
    public class BoogContext : DbContext
    {
        public BoogContext(DbContextOptions<BoogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Boog> Bogen { get; set; }
        public DbSet<Categorie> Categories { get; set; }
    }

}