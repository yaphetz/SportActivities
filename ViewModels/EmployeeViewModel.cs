using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SportActivities.Models;

namespace SportActivities.ViewModels
{
    public class EmployeeViewModel
    {

        static PasswordHasher<Employee> hasher = new PasswordHasher<Employee>();

       public IEnumerable<Employee> Employees;
    }
}
