using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.core.Reposatories
{
    public interface IbaseRepo<T> where T : class
    {
       Task< T> GetById(int id);
        Task<T> AddAsync(T entity);
        T Update(T entity);

        Task<IEnumerable<T>> GetAllAsync();

      void Delete(T entity);
        Task<IEnumerable<T>> FindRangeAsync(int? skip, int? take);



    }
}
