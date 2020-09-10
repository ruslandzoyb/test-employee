using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
   public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get;  }
        public IPositionRepository PositionRepository { get; }
        public IHistoryRepository HistoryRepository { get; }

        Task Save();
    }
}
