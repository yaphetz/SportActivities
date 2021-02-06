using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportActivities.Data;
using SportActivities.Models;
using SportActivities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
//using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace SportActivities.Controllers
{
   
    [Authorize(Roles = "admin")]
    public class EmployeesListController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Employee> userManager;
        private readonly ApplicationDbContext context;


        public EmployeesListController(RoleManager<IdentityRole> roleMgr, UserManager<Employee> usrMgr, ApplicationDbContext appDbContext)
        {
            userManager = usrMgr;
            roleManager = roleMgr;
            context = appDbContext;
        }
        public IActionResult EmployeeTable()
        {
            return View();
        }



        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            var dto = (from employee in context.Employees
                     join choice in context.Choices on employee.Id equals choice.EmployeeId into temp
                     from newTemp in temp.DefaultIfEmpty()
                     select new dto_EmployeeTable
                     {
                         Id = employee.Id,
                         FirstName = employee.FirstName,
                         LastName = employee.LastName,
                         Email = employee.Email,
                         DefaultActivity = newTemp.DefaultActivity != null ? newTemp.DefaultActivity.Name: "-",
                         FirstActivity = newTemp.FirstActivity != null ? newTemp.FirstActivity.Name : "-",
                     });

            
            return await DataSourceLoader.LoadAsync(dto, loadOptions);
        }



        [HttpPost]
        public async Task<IActionResult> Create(string values)
        {
            Employee newEmployee = new Employee();
            JsonConvert.PopulateObject(values, newEmployee);
            newEmployee.UserName = newEmployee.Email;
            newEmployee.EmailConfirmed = true;

            IdentityResult resultCreateEmployee = await userManager.CreateAsync(newEmployee, "PeoplePower@1234");
            IdentityResult resultAsignRoleToEmployee = await userManager.AddToRoleAsync(newEmployee, "basic");
            if (resultCreateEmployee.Succeeded && resultAsignRoleToEmployee.Succeeded)
                return Ok(newEmployee);
            else
            {
                foreach (IdentityError error in resultCreateEmployee.Errors)
                    ModelState.AddModelError("", error.Description);
                foreach (IdentityError error in resultAsignRoleToEmployee.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return Ok(newEmployee);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, string values)
        {
            Employee employee = await userManager.FindByIdAsync(id);
            JsonConvert.PopulateObject(values, employee);

            IdentityResult result = await userManager.UpdateAsync(employee);
            return new EmptyResult();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            Employee employee = await userManager.FindByIdAsync(id);
            if (employee != null)
            {
                IdentityResult result = await userManager.DeleteAsync(employee);
            }
            return Ok();
        }
        //needs testing
        public ActionResult GetListOfEmployeesWithValidChoice()
        {

            var query = from employee in userManager.Users
                        join choice in context.Choices on employee.Id equals choice.Employee.Id
                        where choice.FirstActivity != null || choice.DefaultActivity != null
                        select new Employee { Id = employee.Id, FirstName = employee.FirstName, LastName = employee.LastName, Email = employee.Email };

            var viewModel = new EmployeeViewModel { Employees = query.ToList() };
            return View(viewModel);
        }
    
        //for development
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }

}
