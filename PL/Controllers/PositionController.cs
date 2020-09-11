using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        readonly IPositionService service;
        public PositionController(IPositionService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionDTO>> Get(int id)
        {
            return await service.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<PositionDTO>> Add([FromForm] PositionDTO position)
        {
            return await service.Add(position);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDTO>>> Get(){
            return Ok(await service.GetList());
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Remove(id);
        }
        [HttpPut]
        public async Task Update([FromForm] PositionDTO position)
        {
            await service.Update(position);
        }
    }
}
