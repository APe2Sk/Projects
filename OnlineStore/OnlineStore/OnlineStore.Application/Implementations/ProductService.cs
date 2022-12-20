using AutoMapper;
using OnlineStore.Application.Interfaces;
using OnlineStore.DataAccess.Interfaces;
using OnlineStore.Domain.Entities;
using OnlineStore.ViewModels.Enums;
using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productsRepository;
        private readonly IProductCathegoryRepository _productCathegoryRepository;
        private readonly IProductStatusRepository _productStatusRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productsRepository, IProductCathegoryRepository productCathegoryRepository, IProductStatusRepository productStatusRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _productCathegoryRepository = productCathegoryRepository;
            _productStatusRepository = productStatusRepository;
            _mapper = mapper;
        }


        public List<ProductViewModel> GetAllProducts()
        {
            var allProducts = _productsRepository.GetAll().ToList();
            var mappingOfAllProducts = allProducts.Select(x => _mapper.Map<ProductViewModel>(x)).ToList();

            return mappingOfAllProducts;
        }

        public ProductViewModel GetProduct(int id)
        {
            var product = _productsRepository.GetById(id);

            return _mapper.Map<ProductViewModel>(product);
        }

        public ProductViewModel InsertProduct(ProductViewModel newProduct)
        {
            var mappedNewProduct = _mapper.Map<Product>(newProduct);

            var productCathegory = _productCathegoryRepository.GetByName(newProduct.ProductCathegoryName);
            mappedNewProduct.ProductCathegory = productCathegory;
            mappedNewProduct.ProductCathegoryId = productCathegory.Id;

            if (newProduct.Quantity > 0)
            {
                var status = ProductStatusEnum.InStock.ToString();
                mappedNewProduct.ProductStatus = _productStatusRepository.GetByName(status);
                mappedNewProduct.ProductStatusId = _productStatusRepository.GetByName(status).Id;
            }
            else
            {
                var status = ProductStatusEnum.OutOfStock.ToString();
                mappedNewProduct.ProductStatus = _productStatusRepository.GetByName(status);
                mappedNewProduct.ProductStatusId = _productStatusRepository.GetByName(status).Id;
            }


            return newProduct;
        }

        public ProductViewModel UpdateProduct(ProductViewModel updatedProduct)
        {
            throw new NotImplementedException();
        }
        public ProductViewModel DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
