using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Minor.Dag16.NorthWind
{
    public class ProductRepository : IRepository<Products, int>
    {

        public IEnumerable<Products> FindAll()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.Include(p => p.Category).Select(product => product).ToList();
            }
        }

        public IEnumerable<Products> FindBy(Expression<Func<Products, bool>> filter)
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.Where(filter).Select(product => product).ToList();
            }
        }

        public void Insert(Products item)
        {
            using (var context = new NorthwindContext())
            {
                context.Products.Add(item);
                if (context.Categories.Any(Category => Category.CategoryName != item.Category.CategoryName))
                {
                    context.Categories.Add(item.Category);
                }
                context.SaveChanges();
            }
        }

        public void Update(Products item)
        {
            using (var context = new NorthwindContext())
            {
                context.Products.Update(item);
                if (context.Categories.Any(Category => Category.CategoryName != item.Category.CategoryName))
                {
                    context.Categories.Add(item.Category);
                }
                context.SaveChanges();
            }
        }

        public void Delete(Products item)
        {
            using (var context = new NorthwindContext())
            {
                context.Products.Remove(item);
                context.SaveChanges();
            }
        }

    }
}
