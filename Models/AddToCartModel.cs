using EasyLearningLTD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLearningLTD.Models
{
    public class AddToCartModel
    {
        public int Id { get; set; }

        public string CourseTitle { get; set; }

        public int Price { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }

        public AddToCartDomain ToCartDomain()
        {
            return new AddToCartDomain()
            {
                Id =this.Id,
                CourseTitle = this.CourseTitle,
                Price= this.Price,
                Status = this.Status,
                Quantity = this.Quantity
            };

        }
    }

   
}
