using Domain.Entities.Product;

namespace Domain.Abstraction;

public interface IProductRepository
{
    Task InsertAsync(Product product);
}