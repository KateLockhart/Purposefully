using Purposefully.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Models.EntryModels
{
    public class EntryCreate
    {
        public Guid Author { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Your journal entry title cannot be more than 200 characters or less than 3.")]
        public string EntryTitle { get; set; }

        [Required]
        [StringLength(8000, MinimumLength = 3, ErrorMessage = "Your entry contents cannot be more than 8000 characters or less than 3.")]
        public string EntryContent { get; set; }

        [Required]
        [Display(Name = "Is this for one of your goals?")]
        public bool ForGoal { get; set; }

        [ForeignKey(nameof(Goal))]
        public string GoalTitle { get; set; }
        public virtual Goal Goal { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
