using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
   public interface IHistoryRepository :IRepository<EmployeePosition>
    {
        Task<EmployeePosition> GetWithDetails(int id);
        Task<IEnumerable<EmployeePosition>> GetListWithDetails();
    }
}
