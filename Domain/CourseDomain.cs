using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearningLTD.Domain
{
    public class CourseDomain
    {
        public int Id { get; set; }

        public string  CourseTitle{ get; set; }

        public int Price { get; set; }

        public string Status { get; set; }
        
    }
}
