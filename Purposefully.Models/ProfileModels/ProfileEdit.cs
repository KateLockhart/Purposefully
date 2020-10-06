using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Models.ProfileModels
{
    public class ProfileEdit
    {
        [Required]
        public int ProfileId { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "First name should be between 3 and 20 characters.")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "First name should be between 3 and 20 characters.")]
        public string LastName { get; set; }

        [StringLength(500, MinimumLength = 0, ErrorMessage = "I'm sorry, your motivation section cannot be over 500 characters.")]
        public string Motivation { get; set; }
    }
}
