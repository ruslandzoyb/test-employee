using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Domain.DTO;
using Domain.Interfaces;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
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
            BLValidation.CheckEmployee(entity);
            var exist = await IsEmployeeExist(entity);
            if (exist!=null)
            {
                return mapper.Map<EmployeeDTO>(exist);
            }

           var model= await db.EmployeeRepository.Add(mapper.Map<Employee>(entity));           
            await db.Save();
            entity.Id = model.Id;
            return entity;

        }

        public async Task<EmployeeDTO> Get(int id)
        {
            return mapper.Map<EmployeeDTO>(await db.EmployeeRepository.Get(id));
        }

        public async Task<IEnumerable<EmployeeDTO>> GetList()
        {
           return  mapper.Map<IEnumerable<EmployeeDTO>>( await db.EmployeeRepository.GetListWithDetails());
        }

        public async Task Remove(int id)
        {
            await db.EmployeeRepository.Delete(id);
            await db.Save();

        }

        public async Task Update(EmployeeDTO entity)
        {
            BLValidation.CheckEmployee(entity);
            db.EmployeeRepository.Update(mapper.Map<Employee>(entity));
            await db.Save();
        }

        private async Task<Employee> IsEmployeeExist(EmployeeDTO employee)
        {
            // var entity =await db.EmployeeRepository.Get(employee.Id);
            var entity =await  db.EmployeeRepository.Get(x => x.Name == employee.Name && x.Surname == employee.Surname);
            if (entity is null)
            {
                return null; 
            }
            return entity;
        }
    }
}
