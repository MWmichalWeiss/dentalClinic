using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practikumProject.Models;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practikumProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleEmployeeController : ControllerBase
    {
        private readonly IRoleEmployeeService _roolEmployeeService;

        private readonly IMapper _mapper;

        public RoleEmployeeController(IRoleEmployeeService roolEmployeeService, IMapper mapper)
        {
            _roolEmployeeService = roolEmployeeService;
            _mapper = mapper;
        }

        // GET: api/<RoolEmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _roolEmployeeService.GetAllRoleEmployeesAsync());
        }

        // GET api/<RoolEmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var r = _roolEmployeeService.GetRoleEmployeeById(id);
            return Ok(_mapper.Map<RoleEmployeeDto>(r));
        }

        // POST api/<RoolEmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleEmployeePostModel value)
        {
            var toAdd = new RoleEmployee { EmployeeId = value.EmployeeId, RoleId = value.RoleId, EntryDate = value.EntryDate, Status = value.Status };

            return Ok(await _roolEmployeeService.AddRoleEmployeeAsync(toAdd));
        }

        [HttpPost("addRoles")]
        public async Task<ActionResult> Post([FromBody] IEnumerable<RoleEmployeePostModel> values)
        {
            foreach (var item in values)
            { Post(item); }
            return Ok();
            //    var toAdd = new RoleEmployee();
            //foreach (var item in values)
            //{
            //     toAdd = new RoleEmployee { EmployeeId = item.EmployeeId, RoleId = item.RoleId, EntryDate = item.EntryDate, Status = item.Status };
            //}
            //return Ok(await _roolEmployeeService.AddRoleEmployeeAsync(toAdd));
        }



        // PUT api/<RoolEmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RoleEmployeePostModel value)
        {
            var toUpdate = new RoleEmployee { EmployeeId = value.EmployeeId, RoleId = value.RoleId, EntryDate = value.EntryDate, Status = value.Status };

            return Ok(_roolEmployeeService.UpdateRoleEmployee(id, toUpdate));

        }

        // DELETE api/<RoolEmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var value = _roolEmployeeService.GetRoleEmployeeById(id);

            if (value is null)
                return NotFound();

            await _roolEmployeeService.DeleteRoleEmployeeAsync(id);
            return NoContent();
        }
    }
}
