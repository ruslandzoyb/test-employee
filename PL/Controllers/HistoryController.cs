using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Interfaces;
using Domain.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        IHistoryService service;

        public HistoryController(IHistoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<History>>> GetEmployeesHistory()
        {
                return Ok(await service.GetList());          
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<History>> Get(int id)
        {
            return await  service.Get(id);
        }

        [HttpPost]
        public async Task<History> AddHistory( [FromBody]HistoryView history )
        {
            try
            {
                return await service.Add(MapperHelp.GetHistory(history));
            }
            catch (CustomException ex)
            {

                return null;
            }
            
        }

        [HttpDelete]
        public async Task DeleteHistory(int id)
        {
            await service.Remove(id);
        }


        [HttpPut]
        public async Task<ActionResult> Update(History history)
        {
            await service.Update(history);
            return Ok();


        }
    }
}
