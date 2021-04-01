using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using EasyLearningLTD.Domain;

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

        public TutorRatingDomain ToTutorRatingDomain()
        {
            return new TutorRatingDomain()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                TutorID = this.TutorID,
                CourseID = this.CourseID,
                Helpfulness = this.Helpfulness,
                Quality = this.Quality,
                Professionalism = this.Professionalism,
                Workload = this.Workload,
                OverAllRating = this.OverAllRating
            };
        }

    }
 

}
