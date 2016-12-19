using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarFinderApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Car> Cars { get; set; }

        // Start adding code for ApplicationDbContext to recognize and use stored procedures
        // GetAllYears
        public async Task<List<string>> GetAllYears()
        {
            return await this.Database.SqlQuery<string>("GetAllYears").ToListAsync();
        }

        public async Task<List<string>> GetMakesByYear(string year)
        {
            return await this.Database.SqlQuery<string>("GetMakesByYear @year",
                new SqlParameter("year", year)).ToListAsync();
        }

        public async Task<List<string>> GetModelByYear(string year)
        {
            return await this.Database.SqlQuery<string>("GetModelByYear @year",
                new SqlParameter("year", year)).ToListAsync();
        }

        public async Task<List<string>> GetModelByYearAndMake(string year, string make)
        {
            return await this.Database.SqlQuery<string>("GetMakesByYear @year, @make",
                new SqlParameter("year", year),
                new SqlParameter("make", make)).ToListAsync();
        }

        public async Task<List<string>> GetTrimByYearMakeModel(string year, string make, string model)
        {
            return await this.Database.SqlQuery<string>("GetMakesByYear @year, @make, @model",
                new SqlParameter("year", year),
                new SqlParameter("make", make),
                new SqlParameter("model", model)).ToListAsync();
        }

        public async Task<List<Car>> GetCarsByYear(string year)
        {
            return await this.Database.SqlQuery<Car>("GetCarsByYearAndMake @year",
                new SqlParameter("year", year)).ToListAsync();
        }

        public async Task<List<Car>> GetCarsByYearAndMake(string year, string make)
        {
            return await this.Database.SqlQuery<Car>("GetCarsByYearAndMake @year, @make",
                new SqlParameter("year", year),
                new SqlParameter("make", make)).ToListAsync();
        }

        public async Task<List<Car>> GetCarsByYearMakeAndModel(string year, string make, string model)
        {
            return await this.Database.SqlQuery<Car>("GetCarsByYearAndMake @year, @make, @model",
                new SqlParameter("year", year),
                new SqlParameter("make", make),
                new SqlParameter("model", model)).ToListAsync();
        }

        public async Task<List<Car>> GetCarsByYearMakeModelAndTrim(string year, string make, string model, string trim)
        {
            return await this.Database.SqlQuery<Car>("GetCarsByYearAndMake @year, @make, @model, @trim",
                new SqlParameter("year", year),
                new SqlParameter("make", make),
                new SqlParameter("model", model),
                new SqlParameter("trim", trim)).ToListAsync();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}