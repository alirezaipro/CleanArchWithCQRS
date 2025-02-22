namespace Application.Products.Commands;

public class CreateProductRequestDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Tags { get; set; }

    public int Price { get; set; }
}