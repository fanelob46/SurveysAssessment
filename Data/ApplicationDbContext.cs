using SurveysAssessment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SurveysAssessment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserFavouriteFoods> UserFavouriteFoods { get; set; }

        public DbSet<UserActivityRatings> UserActivityRatings { get; set; }

    }
}
