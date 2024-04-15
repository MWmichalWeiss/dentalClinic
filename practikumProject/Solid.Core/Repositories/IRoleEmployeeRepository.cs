using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IRoleEmployeeRepository
    {
        Task<IEnumerable<RoleEmployee>> GetAllRoleEmployeesAsync();
        RoleEmployee GetRoleEmployeeById(int id);
        Task<RoleEmployee> AddRoleEmployeeAsync(RoleEmployee value);
        RoleEmployee UpdateRoleEmployee(int id, RoleEmployee value);
        Task DeleteRoleEmployeeAsync(int id);
    }
}
