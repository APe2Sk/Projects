using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.DataAccess.EntityFramework;
using OnlineStore.DataAccess.Implementations;
using OnlineStore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess
{
    public static class Module
    {
        public static IServiceCollection AddInfrastracture (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IProductStatusRepository, ProductStatusRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCathegoryRepository, ProductCathegoryRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderLineItemRepository, OrderLineItemRepository>();
            services.AddScoped<IInvoiceStatusRepository, InvoiceStatusRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceLineItemRepository, InvoiceLineItemRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
            return services;
        }
    }
}
