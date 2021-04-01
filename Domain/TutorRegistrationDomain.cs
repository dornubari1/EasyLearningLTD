using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearningLTD.Domain
{
    public class TutorRegistrationDomain
    {
      
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string AvailableCourses { get; set; }

        public string Availability { get; set; }

        public string Password { get; set; }

    }
}
