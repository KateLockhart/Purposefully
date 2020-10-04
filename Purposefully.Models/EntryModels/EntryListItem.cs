using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Models.EntryModels
{
    public class EntryListItem
    {
        [Display(Name = "Journal Entry ID #")]
        public int EntryId { get; set; }

        [Display(Name = "Author")]
        public Guid Author { get; set; }

        [Display(Name = "Journal Entry Title")]
        public string EntryTitle { get; set; }

        [Display(Name = "Journal Entry")]
        public string EntryContent { get; set; }

        //Potentially not including as List Item but for Detail only
        /*[Display(Name = "For a goal?")]
        public bool ForGoal { get; set; }

        [Display(Name = "Goal Title")]
        public string GoalTitle { get; set; }*/

        [Display(Name = "Created on")]
        public DateTimeOffset CreatedUtc { get; set; }
        /*public DateTimeOffset? ModifiedUtc { get; set; }*/
    }
}
