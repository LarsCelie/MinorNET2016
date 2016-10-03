using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Minor.Dag16.DatabaseTestDriven
{

    public class BoogRepository : IRepository<Boog, int>
    {
        private DbContextOptions<BoogContext> _options;

        public BoogRepository(DbContextOptions<BoogContext> options)
        {
            _options = options;
        }

        public void Delete(Boog item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Boog> FindAll()
        {
            using (var context = new BoogContext(_options))
            {
                return context.Bogen.Include(b => b.Categorie).ToList();
            }
        }

        public IEnumerable<Boog> FindBy(Expression<Func<Boog, bool>> filter)
        {
            using (var context = new BoogContext(_options))
            {
                return context.Bogen.Include(b => b.Categorie).Where(filter).ToList();
            }
        }

        public Boog FindById(int key)
        {
            using (var context = new BoogContext(_options))
            {
                return context.Bogen.Include(b => b.Categorie).Where(b => b.Id == key).Single();
            }
        }

        public void Insert(Boog item)
        {
            using (var context = new BoogContext(_options))
            {
                if (context.Categories.Any(cat => cat.Naam == item.Categorie.Naam))
                {
                    item.Categorie = context.Categories.Where(cat => cat.Naam == item.Categorie.Naam).First();
                }
                context.Bogen.Add(item);
                context.SaveChanges();
            }
        }

        public void Update(Boog item)
        {
            using (var context = new BoogContext(_options))
            {
                context.Bogen.Update(item);
                context.SaveChanges();
            }
        }
    }
}