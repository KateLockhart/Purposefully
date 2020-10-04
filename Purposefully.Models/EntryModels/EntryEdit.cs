using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Models.EntryModels
{
    public class EntryEdit
    {
        [Required]
        public int EntryId { get; set; }
        public string EntryTitle { get; set; }
        public string EntryContent { get; set; }

        [Display(Name = "Is this for one of your goals?")]
        public bool ForGoal { get; set; }

        [Display(Name = "Goal")]
        public string GoalTitle { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
