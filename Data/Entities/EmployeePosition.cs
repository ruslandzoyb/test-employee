using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class EmployeePosition :BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
        public double Salary { get; set; }


        public DateTime Hired { get; set; }

        public DateTime? Fired { get; set; }
    }
}
