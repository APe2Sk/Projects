using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.EntitiesConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Price).IsRequired().HasPrecision(10, 2);
            builder.Property(x => x.DiscountPercetage).HasDefaultValue(0);

            builder.HasOne(x => x.ProductStatus)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductStatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Product_ProductStatus");

            builder.HasOne(x => x.ProductCathegory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductCathegoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Product_ProductCategory");
        }
    }
}
