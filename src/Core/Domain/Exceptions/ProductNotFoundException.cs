using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(string productId) : base(
        $"Product with id {productId} was not found."
    )
    {
    }
}