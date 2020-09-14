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
    public class HistoryRepository : Repository<EmployeePosition>, IHistoryRepository
    {
        public HistoryRepository(EmployeeContext context):base(context)
        {

        }
        public async Task<IEnumerable<EmployeePosition>> GetListWithDetails()
        {
            return await dbset.Include(x => x.Employee).Include(x => x.Position).ToListAsync();
                
            
        }

        public async Task<EmployeePosition> GetWithDetails(int id)
        {
            return await dbset.Include(x=>x.Position).Include(x=>x.Employee)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
