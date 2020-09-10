using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
   public class PositionRepository :Repository<Position>,IPositionRepository
    {
        public PositionRepository(EmployeeContext context) : base(context)
        {

        }

    }
}
