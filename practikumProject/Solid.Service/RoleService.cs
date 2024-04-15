using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRoleAsync()
        {
            return await _roleRepository.GetAllRoleAsync();
        }

        public Role GetRoleById(int id)
        {
            return _roleRepository.GetRoleById(id);
        }

        public async Task<Role> AddRoleAsync(Role value)
        {
            return await _roleRepository.AddRoleAsync(value);
        }

        public Role UpdateRole(int id, Role value)
        {
            return _roleRepository.UpdateRole(id, value);
        }

        public async Task DeleteRoleAsync(int id)
        {
           await _roleRepository.DeleteRoleAsync(id);
        }

        //public async Task<IEnumerable<string>> GetRoleNames()
        //{
        //    await _roleRepository.GetRoleNames();
        //}
    }
}
