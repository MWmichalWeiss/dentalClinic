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
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context= context;
        }

        public async Task<IEnumerable<Role>> GetAllRoleAsync()
        {
            return await _context.RoleList.ToListAsync();
        }

        public Role GetRoleById(int id)
        {
            return _context.RoleList.Include(x=>x.Employees).First(x=>x.Id==id);
        }

        public async Task<Role> AddRoleAsync(Role value)
        {
            _context.RoleList.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public Role UpdateRole(int id, Role value)
        {
            var exist = GetRoleById(id);

            if (exist != null)
            {
                exist.IsManager = value.IsManager;
                exist.DescriptionRole = value.DescriptionRole;

                _context.SaveChanges();

                return exist;
            }

            return null;
        }

        public async Task DeleteRoleAsync(int id)
        {
            var v = GetRoleById(id);

            _context.RoleList.Remove(v);

            await _context.SaveChangesAsync();
        }

        //public async Task<IEnumerable<string>> GetRoleNames()
        //{
        //    return await _context
        //}
    }
}
