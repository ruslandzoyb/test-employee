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
    public class PositionService : IPositionService
    {
       readonly IUnitOfWork db;
        readonly IMapper mapper;
        public PositionService(IUnitOfWork db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        public async Task<PositionDTO> Add(PositionDTO entity)
        {
            BLValidation.CheckPosition(entity);
            var exist = await IsPositionExist(entity);
            if (exist != null)
            {
                return mapper.Map<PositionDTO>(exist);
            }
          var position=  await db.PositionRepository.Add(mapper.Map<Position>(entity));
            await db.Save();
            entity.Id = position.Id;
            return entity;
        }

        public async Task<PositionDTO> Get(int id)
        {
            return mapper.Map<PositionDTO>(await db.PositionRepository.Get(id));
        }

        public async Task<IEnumerable<PositionDTO>> GetList()
        {
            return mapper.Map<IEnumerable<PositionDTO>>(await db.PositionRepository.GetList());
        }

        public async Task Remove(int id)
        {
            await db.PositionRepository.Delete(id);
            await db.Save();
        }

        public async Task Update(PositionDTO entity)
        {
            BLValidation.CheckPosition(entity);
            db.PositionRepository.Update(mapper.Map<Position>(entity));
            await db.Save();
        }
        private async Task<Position> IsPositionExist(PositionDTO position)
        {
            
            var entity = await db.PositionRepository.Get(x => x.Title==position.Title);
            if (entity is null)
            {
                return null;
            }
            return entity;
        }
    }
}
