using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EasyLearningLTD.Domain;

namespace EasyLearningLTD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EasyLearningLTD.Domain.TutorRegistrationDomain> TutorRegistrationTable { get; set; }
        public DbSet<EasyLearningLTD.Domain.TutorRatingDomain> TutorRatingTable { get; set; }
        public DbSet<EasyLearningLTD.Domain.CourseDomain> CourseTable { get; set; }
    }
}
