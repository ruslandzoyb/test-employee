using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class History
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDTO Employee { get; set; }

        public int PositionId { get; set; }
        public PositionDTO Position { get; set; }
        public double Salary { get; set; }

        public DateTime Hired { get; set; } 
        public DateTime ? Fired { get; set; }


    }
}
