using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItem { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLineItem> OrderLineItem { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCathegory> ProductCathegory { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

    }
}
