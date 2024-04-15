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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
           return await _employeeRepository.GetAllEmployeesAsync();
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee value)
        {
            return await _employeeRepository.AddEmployeeAsync(value);
        }

        public Employee UpdateEmployee(int id, Employee value)
        {
            return _employeeRepository.UpdateEmployee(id, value);
        }

        public Employee UpdateStatusEmployee(int id)
        {
            return _employeeRepository.UpdateStatusEmployee(id);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
