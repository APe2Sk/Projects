using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Interfaces
{
    public interface IProductCathegoryRepository
    {
        List<ProductCathegory> GetAll();
        ProductCathegory GetById(int id);
        ProductCathegory GetByName(string cathegory);

        ProductCathegory CreateCathegory(ProductCathegory newCathegory);
        ProductCathegory UpdateCathegory(ProductCathegory updatedCathegory);
        void DeleteCathegory(ProductCathegory deletedCathegory);
    }
}
