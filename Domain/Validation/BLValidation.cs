using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validation
{
   public static class BLValidation
    {

        public static void  CheckPosition(PositionDTO position)
        {
            if (position is null)
            {
                throw new CustomException("position is null");
            }
            if (position.Title is null)
            {
                throw new CustomException("title is null");
            }
            if (position.Title.Length==0)
            {
                throw new CustomException("title is empty");
            }
            if (String.IsNullOrWhiteSpace(position.Title))
            {
                throw new CustomException("title is whitespace");
            }
        }

        public static void CheckEmployee(EmployeeDTO employee)
        {
            
            if (employee is null)
            {
                throw new CustomException("employee is null");
            }
            if (employee.Name is null)
            {
                throw new CustomException("Name is null");
            }
            if (employee.Name.Length == 0)
            {
                throw new CustomException("Name is empty");
            }
            if (String.IsNullOrWhiteSpace(employee.Name))
            {
                throw new CustomException("Name is whitespace");
            }
            if (employee.Surname is null)
            {
                throw new CustomException("Surname is null");
            }
            if (employee.Surname.Length == 0)
            {
                throw new CustomException("Surname is empty");
            }
            if (String.IsNullOrWhiteSpace(employee.Surname))
            {
                throw new CustomException("Surname is whitespace");
            }

        }

        public static void CheckHistory(History history)
        {
            
            if (history is null)
            {
                throw new CustomException("history is null");
            }
            if (history.Salary<0)
            {
                throw new CustomException("salary  is smaller than 0");
            }
            if (history.PositionId==0||history.PositionId==default)
            {
                throw new CustomException("PositionId is zero or default ");
            }
            if (history.EmployeeId == 0 || history.EmployeeId == default)
            {
                throw new CustomException("EmployeeId is zero or default ");
            }
            if (history.Hired>DateTime.Now)
            {
                throw new CustomException("Hired is incorrect  ");
            }
        }
             
    }
}
