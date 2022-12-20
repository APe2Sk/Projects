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
    public class ProductCathegoryConfig : IEntityTypeConfiguration<ProductCathegory>
    {
        public void Configure(EntityTypeBuilder<ProductCathegory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CathegoryName).IsRequired().HasMaxLength(255);
        }
    }
}
