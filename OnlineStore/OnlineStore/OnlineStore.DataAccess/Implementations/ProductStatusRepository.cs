using OnlineStore.DataAccess.EntityFramework;
using OnlineStore.DataAccess.Interfaces;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Implementations
{
    public class ProductStatusRepository : BaseRepository, IProductStatusRepository
    {
        public ProductStatusRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public ProductStatus CreateStatus(ProductStatus newStatus)
        {
            _context.ProductStatus.Add (newStatus);
            _context.SaveChanges();

            return newStatus;
        }

        public void DeleteStatus(ProductStatus deletedStatus)
        {
            _context.ProductStatus.Remove(deletedStatus);
            _context.SaveChanges();

        }

        public ProductStatus UpdateStatus(ProductStatus updatedStatus)
        {
            _context.ProductStatus.Update(updatedStatus);
            _context.SaveChanges();

            return updatedStatus;
        }

        public List<ProductStatus> GetAll()
        {
            return _context.ProductStatus.ToList();
        }

        public ProductStatus GetById(int id)
        {
            return _context.ProductStatus.FirstOrDefault(x => x.Id == id);
        }

        public ProductStatus GetByName(string status)
        {
            return _context.ProductStatus.FirstOrDefault(x => x.StatusName == status);
        }
    }
}
