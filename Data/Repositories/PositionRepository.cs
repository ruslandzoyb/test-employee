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
   public class PositionRepository :Repository<Position>,IPositionRepository
    {
        public PositionRepository(EmployeeContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Position>> WithDetails()
        {
          return   await dbset.Include(x => x.Employees).ThenInclude(x=>x.Employee).ToListAsync() ;
            
        }
    }
}
