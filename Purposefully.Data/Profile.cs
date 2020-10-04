using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Data
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        [Required(ErrorMessage = "Please write your first name.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First name should be between 3 and 20 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please write your last name.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First name should be between 3 and 20 characters.")]
        public string LastName { get; set; }
        public string FullName { get; set; }

        [StringLength(500, MinimumLength = 0, ErrorMessage = "I'm sorry, your motivation section cannot be over 500 characters.")]
        public string Motivation { get; set; }
        public virtual ICollection<Goal> GoalsOfUser { get; set; } = new List<Goal>();

    }
}
