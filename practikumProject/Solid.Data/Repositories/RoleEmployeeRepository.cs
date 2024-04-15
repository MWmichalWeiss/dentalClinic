using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class RoleEmployeeRepository : IRoleEmployeeRepository
    {
        private readonly DataContext _context;
        public RoleEmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleEmployee>> GetAllRoleEmployeesAsync()
        {
            return await _context.RoleEmployeeList.Include(x=>x.Employee).ToListAsync();
        }

        public RoleEmployee GetRoleEmployeeById(int id)
        {
            return _context.RoleEmployeeList.Include(x=>x.Employee).First(x=>x.Id==id);
        }

        public async Task<RoleEmployee> AddRoleEmployeeAsync(RoleEmployee value)
        {
            _context.RoleEmployeeList.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public RoleEmployee UpdateRoleEmployee(int id, RoleEmployee value)
        {
            var exist = GetRoleEmployeeById(id);

            if (exist != null)
            {
                exist.Status = value.Status;

                _context.SaveChanges();

                return exist;
            }

            return null;
        }

        public async Task DeleteRoleEmployeeAsync(int id)
        {
            var v = GetRoleEmployeeById(id);

            _context.RoleEmployeeList.Remove(v);

            await _context.SaveChangesAsync();
        }
    }
}
