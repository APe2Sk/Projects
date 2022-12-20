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
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public void DeleteById(Product product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Product.FirstOrDefault(x => x.Id == id);
        }

        public Product Insert(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
            return product;
        }
    }
}
