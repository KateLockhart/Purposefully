using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Data
{
    public enum GoalType 
    { 
        Career,
        Education,
        Experiential,
        Financial,
        Fitness,
        Life,
        Nutrition,
        Personal,
        Relationship,
        Spiritual
    }
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }

        [Required]
        public string GoalTitle { get; set; }

        [Required]
        public string GoalContent { get; set; }
        public GoalType GoalType { get; set; }

        [Required]
        public int Difficulty { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }



        [ForeignKey(nameof(Profile))]
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public virtual ICollection<Entry> AllEntriesForGoal { get; set; } = new List<Entry>();
    }
}
