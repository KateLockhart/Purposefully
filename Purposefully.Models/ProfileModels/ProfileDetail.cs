using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purposefully.Models.ProfileModels
{
    class ProfileDetail
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
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
    }
}
