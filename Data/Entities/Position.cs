using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class Position:BaseEntity
    {
        public string Title { get; set; }
        public List<EmployeePosition> Employees { get; set; }
    }
}
