using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
