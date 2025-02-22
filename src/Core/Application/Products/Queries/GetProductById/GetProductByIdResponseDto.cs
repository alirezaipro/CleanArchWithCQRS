namespace Application.Products.Queries.GetProductById;

public class GetProductByIdResponseDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Tags { get; set; }

    public double Price { get; set; }
}