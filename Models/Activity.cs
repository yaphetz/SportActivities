using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportActivities.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? Status { get; set; }

        //navigation property
        public ICollection<Choice> FirstChoices { get; set; }
        public ICollection<Choice> DefaultChoices { get; set; }

    }
}
