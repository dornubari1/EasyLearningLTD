using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace EasyLearningLTD.Models
{
    public class TutorRatingModel
    {

        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your tutor first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter your tutor last name")]
        public string LastName { get; set; }

        public int TutorID { get; set; }

        public int CourseID { get; set; }

        public int Helpfulness { get; set; }

        public int Quality { get; set; }

        public int Professionalism { get; set; }

        public int Workload { get; set; }

        public int OverAllRating { get; set; }

    }
 

}
