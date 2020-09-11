using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
   public class PositionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<EmplyeeDTO> Emplyees { get; set; }
    }
}
