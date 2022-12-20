using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Interfaces
{
    public interface IProductService
    {
        ProductViewModel InsertProduct(ProductViewModel newProduct);
        ProductViewModel UpdateProduct(ProductViewModel updatedProduct);
        ProductViewModel DeleteProduct(int id);
        ProductViewModel GetProduct(int id);
        List<ProductViewModel> GetAllProducts();
    }
}
