using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Repository.Common
{
    public interface IRepository<T>  where T : class
    {
        Task<IQueryable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Delete(T entity);

    }
}
