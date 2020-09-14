using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeContext context):base(context)
        {

        }
        public async Task<IEnumerable<Employee>> GetListWithDetails()
        {
           return await dbset.Include(x => x.Positions).ThenInclude(x => x.Position).ToListAsync();
           
        }

        public async Task<Employee> GetWithDetails(int id)
        {
            return await dbset.Include(x => x.Positions)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
