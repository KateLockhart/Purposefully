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

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string FullName 
        {
            get
            {
                string fullName = $"{FirstName} {LastName}";
                return fullName;
            }
        }
        public string Motivation { get; set; }
        public virtual ICollection<Goal> GoalsOfUser { get; set; } = new List<Goal>();

    }
}
