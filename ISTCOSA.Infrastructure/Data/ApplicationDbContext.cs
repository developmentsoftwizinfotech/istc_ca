using ISTCOSA.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Infrastructure.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet <UserProfile> userProfiles { get; set; }
        public DbSet <RollNumber> rollNumbers { get; set; }
        public DbSet <Batch> batches { get; set; }
        public DbSet <Country> countries { get; set; }
        public DbSet <State> states { get; set; }
        public DbSet <City> cities { get; set; }
        public DbSet <Company> companies { get; set; }
        public DbSet <Industry> industries { get; set; }
        public DbSet <Profession> professions { get; set; }
        public DbSet <UserWork> userWorks { get; set; }
        public DbSet <UserStudent> userStudents { get; set; }
        public DbSet <PostEmployment> postEmployments { get; set; }
        public DbSet <UserPersonalInformation> UserPersonalInformation { get; set; }

        

    }


}
