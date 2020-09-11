using AutoMapper;
using Data.Entities;
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
        readonly IMapper mapper;

        public EmployeeService(IUnitOfWork db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<EmployeeDTO> Add(EmployeeDTO entity)
        {
           var model= await db.EmployeeRepository.Add(mapper.Map<Employee>(entity));
            entity.Id = model.Id;
            await db.Save();
            return entity;

        }

        public async Task<EmployeeDTO> Get(int id)
        {
            return mapper.Map<EmployeeDTO>(await db.EmployeeRepository.Get(id));
        }

        public async Task<IEnumerable<EmployeeDTO>> GetList()
        {
            return mapper.Map<IEnumerable<EmployeeDTO>>(await db.EmployeeRepository.GetList());
        }

        public async Task Remove(int id)
        {
            await db.EmployeeRepository.Delete(id);
            await db.Save();

        }

        public async Task Update(EmployeeDTO entity)
        {
            db.EmployeeRepository.Update(mapper.Map<Employee>(entity));
            await db.Save();
        }
    }
}
