using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Data.Entities;
using Domain.DTO;
using Domain.Interfaces;
using Domain.Validation;
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            return Ok(await service.GetList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.Remove(id);
            return Ok("removed");
        }

        [HttpPost]
        
        public async Task<IActionResult> Add([FromBody] EmployeeDTO employee) {

            EmployeeDTO model ;
            try
            {
                
              model=   await service.Add(employee);
            }
            catch (CustomException ex)
            {

                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);

        }

    }
}
