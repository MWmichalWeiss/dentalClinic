using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Employee GetEmployeeById(int id);
        Task<Employee> AddEmployeeAsync(Employee value);
        Employee UpdateEmployee(int id, Employee value);
        Employee UpdateStatusEmployee(int id);
        Task DeleteEmployeeAsync(int id);
    }
}
