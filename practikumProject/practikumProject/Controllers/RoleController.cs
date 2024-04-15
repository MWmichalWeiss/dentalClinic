using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using practikumProject.Models;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Service;
using Solid.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practikumProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }


        // GET: api/<RoolController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _roleService.GetAllRoleAsync());
        }

        // GET api/<RoolController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var r = _roleService.GetRoleById(id);
            return Ok(_mapper.Map<RoleDto>(r));
        }

        [HttpGet("GetRoleNames")]
        public async Task<ActionResult<IEnumerable<string>>> GetRoleNames()
        {
            try
            {
                // איסוף תפקידים באופן אסינכרוני
                var rolesTask = _roleService.GetAllRoleAsync();

                // המתן לקבלת תוצאות התפקידים
                var roles = await rolesTask;
                

                // ודא ש-roles אינו null לפני המרת 
                if (roles != null)
                {
                    var roleNames = roles.Select(r => r.DescriptionRole).ToList();
                    return Ok(roleNames);
                }
                else
                {
                    // טיפול במקרה בו לא נמצאו תפקידים (אופציונלי)
                    return NotFound("לא נמצאו תפקידים"); // או רישום הבעיה
                }
            }
            catch (Exception ex)
            {
                // טיפול חינני בחריגים
                return StatusCode(500, ex.Message); // או רישום השגיאה
            }
        }

        // POST api/<RoolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolePostModel value)
        {
            var toAdd = new Role { DescriptionRole = value.DescriptionRool, IsManager = value.IsManager };

            return Ok(await _roleService.AddRoleAsync(toAdd));
        }

        // PUT api/<RoolController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RolePostModel value)
        {
            var toAUpdate = new Role { DescriptionRole = value.DescriptionRool, IsManager = value.IsManager };

            return Ok(_roleService.UpdateRole(id,toAUpdate));
        }

        // DELETE api/<RoolController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var value = _roleService.GetRoleById(id);

            if (value is null)
            {
                return NotFound();
            }

            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
