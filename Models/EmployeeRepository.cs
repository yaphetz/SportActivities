using SportActivities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivities.Models
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly ApplicationDbContext _addDbContext;
        public EmployeeRepository(ApplicationDbContext appDbContext)
        {
            _addDbContext = appDbContext;
        }

        public IEnumerable<Employee> AllEmployees
        {
            get
            {
                return _addDbContext.Employees;
            }
        }
        public Employee GetEmployeeById(string id)
        {
            return _addDbContext.Employees.FirstOrDefault(e => e.Id == id);
        }

    }
}
