using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EasyLearningLTD.Domain;
using System.Threading.Tasks;
using EasyLearningLTD.Models;

namespace EasyLearningLTD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TutorRegistrationDomain> TutorRegistrationTable { get; set; }
        public DbSet<TutorRatingDomain> TutorRatingTable { get; set; }
        public DbSet<CourseDomain> CourseTable { get; set; }
        public DbSet<AddToCartDomain> CartTable { get; set; }

       
    }
}
