using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportActivities.Models;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using SportActivities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using DevExtreme.AspNet.Mvc;
using System.Security.Claims;

namespace SportActivities.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<Employee> userManager;
        private readonly ILogger<HomeController> _logger;

        public PasswordHasher<Employee> hasher = new PasswordHasher<Employee>();

        private readonly IActivityRepository _activity;
        private readonly IChoiceRepository _choice;

        public HomeController(ILogger<HomeController> logger, UserManager<Employee> userManager1, IActivityRepository activity, IChoiceRepository choice)
        {
            _logger = logger;
            userManager = userManager1;
            _activity = activity;
            _choice = choice;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult TopActivities()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult TopEmployees()
        {
            return View();
        }

        //public IActionResult Table()
        //{
        //    return View(new EmployeeViewModel
        //    {
        //        Employees = new List<Employee>()
        //{
        //    new Employee()
        //    {
        //        Id = "b42824b6a-0613-4cbd-a9e6-f1701e926e73",

        //        FirstName = "Alin",
        //        LastName = "Test",
        //        Email = "test@admin.com",
        //        UserName = "test@admin.com",
        //        EmailConfirmed = true,
        //        NormalizedUserName = "test@admin.com".ToUpper(),
        //        NormalizedEmail = "test@admin.com".ToUpper(),
        //        PasswordHash = hasher.HashPassword(null, "admin")
        //    }

        //-------------------- Activities

        [Authorize]
        public object ApprovedActivities()
        {
            return JsonSerializer.Serialize(_activity.AllApprovedActivities);
        }

        public object RejectedActivities()
        {
            return JsonSerializer.Serialize(_activity.AllRejectedActivities);
        }

        public object WaitingForApprovalActivities()
        {
            return JsonSerializer.Serialize(_activity.AllWaitingForApprovalActivities);
        }

        [HttpPost]
        public RedirectToActionResult AddNewActivity(string Name)
        {
            var newActivity = new Models.Activity()
            {
                Name = Name,
                Status = null
            };

            _activity.AddNewActivity(newActivity);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public RedirectToActionResult DeleteActivity(int id)
        {
            _activity.DeleteActivity(id);

            return RedirectToAction("Index");
        }

        //-------------------- States

        public void AproveActivity(int id)
        {
            _activity.GetActivityById(id).Status = true;
            _activity.UpdateActivity();
        }

        public void RejectActivity(int id)
        {
            _activity.GetActivityById(id).Status = false;
            _activity.UpdateActivity();

            var choice = _choice.GetChoiceByFirstActivityId(id);

            if (choice != null)
            {
                choice.FirstActivityId = null;
                _choice.UpdateChoice();
            }
        }

        //-------------------- Choice
        public void SetFirstActivityId(int id)
        {
            SaveChoice(id, true);
        }

        public void SetDefaultActivityId(int id)
        {
            SaveChoice(id, false);
        }

        public RedirectToActionResult SaveChoice(int id, bool whatChoice)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var choices = _choice.AllChoice.Where(e => e.EmployeeId == currentUserId && e.Date.Month == DateTime.Now.Month).ToList() ;

            if (choices.Count() == 0)
            {
                CreateNewChoice(currentUserId, id, whatChoice);
            }
            else
            {
                UpdateChoice(choices, id, whatChoice);
            }

            return RedirectToAction("Index");
        }

        public void CreateNewChoice(string currentUserId, int id, bool whatChoice)
        {
            var newChoice = new Choice()
            {
                EmployeeId = currentUserId,
                FirstActivityId = null,
                DefaultActivityId = null,
                Date = DateTime.Now
            };
            
            _choice.SaveChoice(newChoice);

            var choices = _choice.AllChoice.Where(e => e.EmployeeId == currentUserId && e.Date.Month == DateTime.Now.Month).ToList();

            UpdateChoice(choices, id, whatChoice);
        }

        public void UpdateChoice(IEnumerable<Choice> choices, int id, bool whatChoice)
        {
            foreach (var choice in choices)
            {
                if (whatChoice == true)
                {
                    choice.FirstActivityId = id;
                }
                else
                {
                    choice.DefaultActivityId = id;
                }
                _choice.UpdateChoice();
            }
        }

        [HttpGet]
        public IActionResult HasApprovedSelected(int id)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var choices = _choice.AllChoice.Where(e => e.EmployeeId == currentUserId && e.DefaultActivityId != null);
            if (choices.Count() == 0)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        [HttpGet]
        public IActionResult HasPendingSelected(int id)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var choices = _choice.AllChoice.Where(e => e.EmployeeId == currentUserId && e.FirstActivityId != null) ;
            if (choices.Count() == 0)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        //-------------------- Err

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Employees()
        {
            return View();
        }

    }
}
