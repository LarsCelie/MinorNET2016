using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag16.DatabaseTestDriven
{
    public class BoogContext : DbContext
    {
        public BoogContext() {}

        public BoogContext(DbContextOptions<BoogContext> options) : base(options) {}

        public DbSet<Boog> Bogen { get; set; }
    }

}