using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
   public interface ICrud<T> where T:class
    {
        Task<T> Get(int id);

        Task Remove(int id );

        Task<T> Add(T entity);

        Task Update(T entity);

        Task<IEnumerable<T>> GetList();
    }
}
