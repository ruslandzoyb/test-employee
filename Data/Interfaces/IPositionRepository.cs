using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
   public interface IPositionRepository :IRepository<Position>
    {
        Task<IEnumerable<Position>> WithDetails();
    }
}
