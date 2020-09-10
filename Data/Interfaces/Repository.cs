using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class Repository<T> : IRepository<T>
         where T : BaseEntity
    {
       protected readonly DbSet<T> dbset;
        public Repository(EmployeeContext context)
        {
            if (context!=null)
            {
                dbset = context.Set<T>();
            }
            else
            {
                throw new NullReferenceException(nameof(context));
            }
        }

        public async Task<T> Add(T entity)
        {
          await  dbset.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await dbset.FindAsync(id);
            if (entity!=null)
            {
                dbset.Remove(entity);
            }
        }

        public async Task<T> Get(int id)
        {
          return  await dbset.FindAsync(id);
        }

        public async Task<T> Get(Expression<Func<T,bool>> expression)
        {
            return await dbset.Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetList()
        {
            return await dbset.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetList(Expression<Func<T,bool>> expression)
        {
            return await dbset.Where(expression).ToListAsync();
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
        }
    }
}
