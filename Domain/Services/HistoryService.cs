using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Domain.DTO;
using Domain.Interfaces;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class HistoryService : IHistoryService
    {
        readonly IUnitOfWork db;
        readonly IMapper mapper;
        public HistoryService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<History> Add(History entity)
        {
            BLValidation.CheckHistory(entity);
            var history=  await db.HistoryRepository.Add(mapper.Map<EmployeePosition>(entity));
            await db.Save();
            entity.Id = history.Id;
            return entity;
        }

        public async Task<History> Get(int id)
        {
            return mapper.Map<History>(await db.HistoryRepository.Get(id));
        }

        public async Task<IEnumerable<History>> GetList()
        {
            return mapper.Map<IEnumerable<History>>(await db.HistoryRepository.GetListWithDetails());
        }

        

        public async Task Remove(int id)
        {
            await db.HistoryRepository.Delete(id);
            await db.Save();
        }

        public async Task Update(History entity)
        {
            BLValidation.CheckHistory(entity);
            db.HistoryRepository.Update(mapper.Map<EmployeePosition>(entity));
            await db.Save();

        }
    }
}
