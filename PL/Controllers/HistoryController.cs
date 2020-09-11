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
    public class HistoryController : ControllerBase
    {
        IHistoryService service;

        public HistoryController(IHistoryService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<History>> GetEmployeesHistory()
        {
            return Ok(await service.GetList());
        }

        [HttpPost]
        public async Task<ActionResult<History>> AddHistory([FromForm] History history )
        {
            return Ok(await service.Add(history));
        }
    }
}
