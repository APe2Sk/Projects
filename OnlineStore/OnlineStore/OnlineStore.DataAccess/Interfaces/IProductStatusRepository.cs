using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Interfaces
{
    public interface IProductStatusRepository
    {
        List<ProductStatus> GetAll();
        ProductStatus GetById(int id);
        ProductStatus GetByName(string status);


        ProductStatus CreateStatus(ProductStatus newStatus);
        ProductStatus UpdateStatus(ProductStatus updatedStatus);
        void DeleteStatus(ProductStatus deletedStatus);

    }
}
