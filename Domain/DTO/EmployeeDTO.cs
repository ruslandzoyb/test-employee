using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
   public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<PositionDTO> Positions { get; set; } = new List<PositionDTO>();
    }
}
