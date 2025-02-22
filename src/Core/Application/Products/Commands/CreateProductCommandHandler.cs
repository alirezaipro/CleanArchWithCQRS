using Application.Abstractions.Messaging;
using Domain.Abstraction;
using Domain.Entities.Product;

namespace Application.Products.Commands;

public class CreateProductCommandHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
)
    : ICommandHandler<CreateProductCommand, CreateProductResponseDto>
{
    public async Task<CreateProductResponseDto> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = Product.Create(request.Title, request.Description, request.Tags, request.Price);

        await productRepository.InsertAsync(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateProductResponseDto()
        {
            Id = product.Id
        };
    }
}