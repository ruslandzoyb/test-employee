using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Domain.DTO;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int id)
        {
            return Ok(await service.Get(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.Remove(id);
            return Ok("removed");
        }

        [HttpPost]
        
        public async Task<ActionResult<EmployeeDTO>> Add([FromForm] EmployeeDTO employee) {

            return await service.Add(employee);
        }

    }
}
