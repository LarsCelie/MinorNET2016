using System;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag16.DatabaseTestDriven
{

    public class BoogRepository
    {
        private DbContextOptions<BoogContext> options;

        public BoogRepository(DbContextOptions<BoogContext> options)
        {
            this.options = options;
        }

        public void Add(Boog boog)
        {
            using (var context = new BoogContext(options))
            {
                context.Bogen.Add(boog);
                context.SaveChanges();
            }
        }
    }
}