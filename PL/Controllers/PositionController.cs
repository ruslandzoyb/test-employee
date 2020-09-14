using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Interfaces;
using Domain.Validation;
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
        public async Task<ActionResult<PositionDTO>> Add(  PositionDTO position)
        {
            try
            {
                return await service.Add(position);
            }
            catch (CustomException ex)
            {

                return BadRequest(ex.Message);
            }
            
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
        public async Task<ActionResult> Update([FromForm] PositionDTO position)
        {
            try
            {
                await service.Update(position);
                return Ok();
            }
            catch (CustomException ex)
            {

                return BadRequest(ex.Message);
            }

            
        }
    }
}
