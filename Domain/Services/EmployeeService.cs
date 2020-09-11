using Data.Interfaces;
using Domain.DTO;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IUnitOfWork db;

        public EmployeeService(IUnitOfWork db)
        {
            this.db = db;
        }

        public Task<EmplyeeDTO> Add(EmplyeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<EmplyeeDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmplyeeDTO>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(EmplyeeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
