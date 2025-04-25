using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Entitites;

namespace XPE.SoftwareArch.FinalChallenge.Infra.ProductData;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Price)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(x => x.StockQuantity)
               .IsRequired();

        builder.Property(x => x.Description)
               .HasMaxLength(500);

        builder.ToTable("Products");
    }
}
