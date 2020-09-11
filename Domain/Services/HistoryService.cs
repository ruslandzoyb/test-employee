using AutoMapper;
using Data.Interfaces;
using Domain.DTO;
using Domain.Interfaces;
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
        public Task<History> Add(History entity)
        {
            throw new NotImplementedException();
        }

        public Task<History> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<History>> GetList()
        {
            return mapper.Map<IEnumerable<History>>(await db.HistoryRepository.GetListWithDetails());
        }

        

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(History entity)
        {
            throw new NotImplementedException();
        }
    }
}
