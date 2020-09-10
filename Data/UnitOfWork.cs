using Data.Interfaces;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly EmployeeContext context;

        public UnitOfWork(EmployeeContext context)
        {
            if (context!=null)
            {
                this.context = context;
            }
        }
        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(context);

        public IPositionRepository PositionRepository => new PositionRepository(context);

        public IHistoryRepository HistoryRepository => new HistoryRepository(context);

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
