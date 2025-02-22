using Domain.Abstraction;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class EshopDbContext(DbContextOptions<EshopDbContext> options)
    : DbContext(options),IUnitOfWork
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}