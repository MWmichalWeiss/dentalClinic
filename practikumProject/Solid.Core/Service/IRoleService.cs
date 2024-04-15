using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Service
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoleAsync();
        Role GetRoleById(int id);
        Task<Role> AddRoleAsync(Role value);
        Role UpdateRole(int id, Role value);
        Task DeleteRoleAsync(int id);
        //Task<IEnumerable<string>> GetRoleNames();
    }
}
