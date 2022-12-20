using AutoMapper;
using OnlineStore.Domain.Entities;
using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.AutoMapperConfig
{
    public class ModelMapper
    {
        public static MapperConfiguration GetConfiguration()
        {
            MapperConfiguration cfg = new MapperConfiguration(x =>
            {
                x.CreateMap<UserViewModel, User>()
                            .ForMember(m => m.UserRoleId, m => m.Ignore())
                            .ForMember(m => m.UserRole, m => m.Ignore())
                            .ForMember(m => m.Invoices, m => m.Ignore())
                            .ForMember(m => m.Orders, m => m.Ignore());
                x.CreateMap<User, UserViewModel>();
                x.CreateMap<Role, RoleViewModel>().ReverseMap();

                x.CreateMap<ProductViewModel, Product>()
                            .ForMember(m => m.InvoiceLineItems, m => m.Ignore())
                            .ForMember(m => m.OrderLineItems, m => m.Ignore())
                            .ForMember(m => m.ProductStatus, m => m.Ignore())
                            .ForMember(m => m.ProductStatusId, m => m.Ignore())
                            .ForMember(m => m.ProductCathegory, m => m.Ignore())
                            .ForMember(m => m.ProductCathegoryId, m => m.Ignore())
                            .ReverseMap();

                x.CreateMap<ProductStatusViewModel, ProductStatus>()
                            .ForMember(m => m.Products, m => m.Ignore())
                            .ReverseMap();


                x.CreateMap<ProductCathegoryViewModel, ProductCathegory>()
                            .ForMember(m => m.Products, m => m.Ignore())
                            .ReverseMap();
            });

            return cfg;
        }
    }
}
