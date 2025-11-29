using eCommerce.ProductsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.ProductsService.Infrastructure.Persistence.Context.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ProductID);
            
        builder.Property(x => x.ProductID)
            .HasColumnName("ProductID")
            .ValueGeneratedOnAdd(); 

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Category)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.StockQuantity)
            .IsRequired()
            .HasDefaultValue(0);
    }
}
