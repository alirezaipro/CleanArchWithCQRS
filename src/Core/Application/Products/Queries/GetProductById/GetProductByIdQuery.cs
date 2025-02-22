using Application.Abstractions.Messaging;

namespace Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery : IQuery<GetProductByIdResponseDto>
{
    public Guid Id { get; set; }
}