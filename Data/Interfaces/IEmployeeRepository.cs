using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
   public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> GetWithDetails(int id);
        Task<IEnumerable<Employee>> GetListWithDetails();

       
    }
}
