using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
   public class EmplyeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<PositionDTO> Positions { get; set; }
    }
}
