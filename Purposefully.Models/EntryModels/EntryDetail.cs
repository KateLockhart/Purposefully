using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Models.EntryModels
{
    public class EntryDetail
    {
        [Display(Name = "Journal Entry ID #")]
        public int EntryId { get; set; }

        [Display(Name = "Author")]
        public Guid Author { get; set; }

        [Display(Name = "Journal Entry Title")]
        public string EntryTitle { get; set; }

        [Display(Name = "Journal Entry")]
        public string EntryContent { get; set; }

        [Display(Name = "For a goal?")]
        public bool ForGoal { get; set; }

        [Display(Name = "Goal ID #")]
        public int GoalId { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
