using System;
using System.Linq;
using System.Collections.Generic;
using BackendService.Entities;
using BackendService.Repository;
using Microsoft.EntityFrameworkCore;

public class CursusRepository : IRepository<CursusInstantie, int>
{
    private DbContextOptions<CursusContext> options;

    public CursusRepository(DbContextOptions<CursusContext> options)
    {
        this.options = options;
    }

    public IEnumerable<CursusInstantie> FindAll()
    {
        using (var context = new CursusContext(options))
        {
            return context.CursusInstanties.Include(ci => ci.Cursus).ToList();
        }
    }

    public CursusInstantie FindById(int key)
    {
        using (var context = new CursusContext(options))
        {
            return context.CursusInstanties.Include(ci => ci.Cursus).Single(cursus => cursus.Id == key);
        }
    }

    public void Insert(CursusInstantie item)
    {
        using (var context = new CursusContext(options))
        {
            if (context.Cursussen.Any(c => c.Code == item.Cursus.Code))
            {
                item.Cursus = context.Cursussen.Single(c => c.Code == item.Cursus.Code);
            }
            if (context.CursusInstanties.Include(ci => ci.Cursus).Any(ci => ci.Startdatum == item.Startdatum && ci.Cursus.Code == item.Cursus.Code))
            {
                throw new DuplicateItemException { ErrorCode = "DB001", ErrorMessage = "Duplicate item CursusInstantie" };
            }
            context.CursusInstanties.Add(item);
            context.SaveChanges();
        }
    }
}