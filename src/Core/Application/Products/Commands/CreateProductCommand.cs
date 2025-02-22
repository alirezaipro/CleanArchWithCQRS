using Application.Abstractions.Messaging;

namespace Application.Products.Commands;

public sealed record CreateProductCommand : ICommand<CreateProductResponseDto>
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Tags { get; set; }

    public int Price { get; set; }
}