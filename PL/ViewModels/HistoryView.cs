using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.ViewModels
{
    public class HistoryView
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public string Hired { get; set; }
        public string Fired { get; set; }
        public double Salary { get; set; }
    }

    public static class MapperHelp
    {
      public  static History  GetHistory(HistoryView model)
        {
            return new History()
            {
                Id = model.Id,
                EmployeeId = model.EmployeeId,
                PositionId = model.PositionId,
                Salary = model.Salary,
                Hired = Convert.ToDateTime(model.Hired)


            };
        }
    }
}
