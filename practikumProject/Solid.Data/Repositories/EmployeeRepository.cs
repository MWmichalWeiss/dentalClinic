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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.EmployeeList.Include(x=>x.Roles).ToListAsync();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.EmployeeList.Find(id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee value)
        {
            _context.EmployeeList.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public Employee UpdateEmployee(int id, Employee value)
        {
            var exist = GetEmployeeById(id);

            if (exist != null)
            {
                exist.LastName = value.LastName;
                exist.FirstName = value.FirstName;
                exist.Status = value.Status;

                _context.SaveChanges();

                return exist;
            }

            return null;
        }

        public Employee UpdateStatusEmployee(int id)
        {
            var exist = GetEmployeeById(id);
            if (exist != null)
            {
                exist.Status=false;
                _context.SaveChanges();
                return exist;
            }
            return null;
        }


        public async Task DeleteEmployeeAsync(int id)
        {
            var v = GetEmployeeById(id);

            _context.EmployeeList.Remove(v);

            await _context.SaveChangesAsync();
        }

       
    }
}
