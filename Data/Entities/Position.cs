using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class Position:BaseEntity
    {
        public string Title { get; set; }
        public ICollection<EmployeePosition> Employees { get; set; } =new List<EmployeePosition>();

        
    }
}
