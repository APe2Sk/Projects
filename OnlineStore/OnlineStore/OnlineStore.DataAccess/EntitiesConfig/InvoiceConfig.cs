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
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InvoiceNumber).IsRequired().HasMaxLength(255);
            builder.Property(x => x.InvoiceDate).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Invoice_User");

            builder.HasOne(x => x.Order)
                .WithOne(x => x.Invoice)
                .HasForeignKey<Invoice>(x => x.OrderId)
                .IsRequired()
                .HasConstraintName("FK_Invoice_Order");

            builder.HasOne(x => x.InvoiceStatus)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.InvoiceStatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Invoice_InvoiceStatus");
        }
    }
}
