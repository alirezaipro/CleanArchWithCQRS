using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.ProductConfigs;

public class ProductConfig:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(i => i.Title)
            .IsRequired()
            .HasMaxLength(350);
        
        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(900);
        
        builder.Property(i => i.Tags)
            .IsRequired()
            .HasMaxLength(600);

        builder.Property(i => i.Price)
            .IsRequired();
    }
}