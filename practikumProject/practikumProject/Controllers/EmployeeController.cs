using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practikumProject.Models;
using practikumProject.Models.putModels;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practikumProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService data,IMapper mapper)
        {
            _employeeService = data;
            _mapper = mapper;
        }

        //GET: api/<EmployController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _employeeService.GetAllEmployeesAsync());
        }

        //GET api/<EmployController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var e = _employeeService.GetEmployeeById(id);
            return Ok(_mapper.Map<EmployeeDto>(e));
        }

        // POST api/<EmployController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel value)
        {
            var toAdd = new Employee { FirstName = value.FirstName, LastName=value.LastName, Tz=value.Tz,DateStartWork=value.DateStartWork,Gander=value.Gander,Status=value.Status,DateOfBirth=value.DateOfBirth };

            return Ok(await _employeeService.AddEmployeeAsync(toAdd));
        }

        // PUT api/<EmployController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EmployeePutModel value)
        {
            var toUpdate = new Employee { FirstName = value.FirstName, LastName = value.LastName, Status = value.Status};

            return Ok(_employeeService.UpdateEmployee(id,toUpdate));
        }

        [HttpPut("changeStatus{id}")]
        public ActionResult PutStatus(int id, [FromBody] EmployeePutModel value)
        {
            return Ok(_employeeService.UpdateStatusEmployee(id));
        }

        // DELETE api/<EmployController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var value = _employeeService.GetEmployeeById(id);

            await _employeeService.DeleteEmployeeAsync(id);
            return Ok(value);
        }

       
    }
}
