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
    public class RoleEmployeeService : IRoleEmployeeService
    {
        private readonly IRoleEmployeeRepository _roleEmployeeRepository;

        public RoleEmployeeService(IRoleEmployeeRepository roolEmployeeRepository)
        {
            _roleEmployeeRepository = roolEmployeeRepository;
        }

        public async Task<IEnumerable<RoleEmployee>> GetAllRoleEmployeesAsync()
        {
            return await _roleEmployeeRepository.GetAllRoleEmployeesAsync();
        }

        public RoleEmployee GetRoleEmployeeById(int id)
        {
            return _roleEmployeeRepository.GetRoleEmployeeById(id);
        }

        public async Task<RoleEmployee> AddRoleEmployeeAsync(RoleEmployee value)
        {
            return await _roleEmployeeRepository.AddRoleEmployeeAsync(value);
        }

        public RoleEmployee UpdateRoleEmployee(int id, RoleEmployee value)
        {
             return _roleEmployeeRepository.UpdateRoleEmployee(id, value); 
        }

        public async Task DeleteRoleEmployeeAsync(int id)
        {
            await _roleEmployeeRepository.DeleteRoleEmployeeAsync(id);
        }
    }
}
