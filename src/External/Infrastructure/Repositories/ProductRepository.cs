using Domain.Abstraction;
using Domain.Entities.Product;
using Infrastructure.Context;

namespace Infrastructure.Repositories;

public class ProductRepository(EshopDbContext context)
    : IProductRepository
{
    public async Task InsertAsync(Product product)
    {
        await context.Products.AddAsync(product);
    }
}