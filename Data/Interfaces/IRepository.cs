using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
  public  interface IRepository<T> 
        where T : class 
    {
        Task<T> Add(T entity);
        void Delete(T entity);
        Task Delete(int id);
        Task<T> Get(int id);
        Task<T> Get(Expression<Func<T,bool>> expression);     

        Task<IEnumerable<T>> GetList();
        Task<IEnumerable<T>> GetList(Expression<Func<T,bool>> expression);

        void Update(T entity);
    }
}
