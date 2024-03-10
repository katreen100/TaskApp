using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using task.Ef;
using TaskApp.core.Reposatories;


namespace TaskApp.Ef.Reposatory
{
    public class baseRepo<T> : IbaseRepo<T> where T : class
    {
        TaskContext context;
        public baseRepo( TaskContext taskContext)
        { 
         context=taskContext;
        
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> FindRangeAsync(int? take, int? skip)
        {
            IQueryable<T> query = context.Set<T>();

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            
            return await query.ToListAsync();
        }

        public async Task<T> GetById (int id ) 
        {

            return await context.Set<T>().FindAsync(id);
        
        }

        public T Update(T entity)
        {
            context.Update(entity);
            return entity;
        }

    }
}
