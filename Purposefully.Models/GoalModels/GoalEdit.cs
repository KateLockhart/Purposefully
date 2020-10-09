using Purposefully.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Models.GoalModels
{
    public class GoalEdit
    {
        [Required]
        public int GoalId { get; set; }

        [Required(ErrorMessage = "Please give your a goal a title.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Goal title should be between 3 and 200 characters.")]
        public string GoalTitle { get; set; }

        [Required(ErrorMessage = "Please detail your goal for the best results.")]
        [StringLength(2000, MinimumLength = 3, ErrorMessage = "Your goal description cannot be more than 2000 characters.")]
        public string GoalContent { get; set; }
        public GoalType GoalType { get; set; }

        [Required]
        [IntegerValidator(MinValue = 1, MaxValue =5,
    ExcludeRange = false)]
        public int Difficulty { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }

        [ForeignKey(nameof(Profile))]
        public int ProfileId { get; set; }
    }
}
