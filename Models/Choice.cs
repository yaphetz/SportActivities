using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivities.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public int? FirstActivityId { get; set; } //fk
        public int? DefaultActivityId { get; set; } //fk
        [Required]
        public DateTime Date { get; set; }

        //navigation property
        [Required]
        public Employee Employee { get; set; }
       
        public Activity FirstActivity { get; set; }
        public Activity DefaultActivity { get; set; }

    }
}
