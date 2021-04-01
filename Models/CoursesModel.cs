using EasyLearningLTD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearningLTD.Models
{
    public class CoursesModel
    {
        public int Id { get; set; }

        public string CourseTitle { get; set; }

        public int Price { get; set; }

        public string Status { get; set; }

        public CourseDomain ToCoursesDomain()
        {
            return new CourseDomain()
            {
                Id = this.Id,
                CourseTitle = this.CourseTitle,
                Price = this.Price,
                Status = this.Status
            };
        }
    }
}
