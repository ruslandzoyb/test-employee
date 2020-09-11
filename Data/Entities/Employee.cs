using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public class Employee :BaseEntity
    {
        public string Name { get; set; }
        public  string  Surname { get; set; }

       

       
        public List<EmployeePosition> Positions { get; set; }

    }
}
