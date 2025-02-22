using Domain.Entities.Common;

namespace Domain.Entities.Product;

public class Product : BaseEntity
{
    private Product(string title, string description, string tags, int price)
    {
        Title = title;
        Description = description;
        Tags = tags;
        Price = price;
    }

    private Product()
    {
    }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Tags { get; private set; }

    public double Price { get; private set; }

    public static Product Create(string title, string description, string tags, int price)
    {
        return new Product(title, description, tags, price);
    }
}