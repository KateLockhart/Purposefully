using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Data
{
    //Note: The journal entries of this program are titled "entry" for convience and efficientcy.
    public class Entry
    {
        [Key]
        public int EntryId { get; set; }
        [Required]
        public Guid Author { get; set; }
        [Required]
        public string EntryTitle { get; set; }
        [Required]
        public string EntryContent { get; set; }

        [Required]
        [Display(Name = "Is this for one of your goals?")]
        public bool ForGoal { get; set; }
        
        [ForeignKey(nameof(Goal))]
        public int GoalId { get; set; }
        public virtual Goal Goal { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
