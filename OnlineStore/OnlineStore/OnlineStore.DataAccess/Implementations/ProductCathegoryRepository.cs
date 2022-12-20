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
    public class ProductCathegoryRepository : BaseRepository, IProductCathegoryRepository
    {
        public ProductCathegoryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public ProductCathegory CreateCathegory(ProductCathegory newCathegory)
        {
            _context.ProductCathegory.Add(newCathegory);
            _context.SaveChanges();
            return newCathegory;
        }

        public void DeleteCathegory(ProductCathegory deletedCathegory)
        {
            _context.ProductCathegory.Remove(deletedCathegory);
            _context.SaveChanges();

        }

        public ProductCathegory UpdateCathegory(ProductCathegory updatedCathegory)
        {
            _context.ProductCathegory.Update(updatedCathegory);
            _context.SaveChanges();
            return updatedCathegory;
        }


        public List<ProductCathegory> GetAll()
        {
            return _context.ProductCathegory.ToList();
        }

        public ProductCathegory GetById(int id)
        {
            return _context.ProductCathegory.FirstOrDefault(x => x.Id == id);
        }

        public ProductCathegory GetByName(string cathegory)
        {
            var productCathegory = _context.ProductCathegory.FirstOrDefault(x => x.CathegoryName == cathegory);
            return productCathegory;
        }
    }
}