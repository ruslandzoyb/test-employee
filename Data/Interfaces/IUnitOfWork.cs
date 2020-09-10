using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
   public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get;  }
        public IPositionRepository PositionRepository { get; }
        public IHistoryRepository HistoryRepository { get; }
    }
}
