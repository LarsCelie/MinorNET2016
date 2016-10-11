using BackendService.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

public class CursusContext : DbContext
{
    public CursusContext(DbContextOptions<CursusContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Cursus> Cursussen { get; set; }
    public DbSet<CursusInstantie> CursusInstanties { get; set; }
}