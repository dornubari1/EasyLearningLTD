using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearningLTD.Domain
{
    public class TutorRatingDomain
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; internal set; }
       
        public string LastName { get; internal set; }
        
        public int TutorID { get; internal set; }
       
        public int CourseID { get; internal set; }

        public int Helpfulness { get; internal set; }

        public int Quality { get; internal set; }

        public int Professionalism { get; internal set; }

        public int Workload { get; internal set; }

        public int OverAllRating { get; internal set; }

       
    }
}
