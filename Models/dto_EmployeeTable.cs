using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivities.Models
{
    public class dto_EmployeeTable
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FirstActivity { get; set; }
        public string DefaultActivity { get; set; }

        //public dto_EmployeeTable( string id, string firstName, string secondName, string email, string firstActivity, string defaultActivity)
        //{
        //    Id = id;
        //    FirstActivity = firstActivity;
        //    DefaultActivity = defaultActivity;
        //    Email = email;
        //    FirstName = firstName;
        //    LastName = secondName;
        //}
    }
}
