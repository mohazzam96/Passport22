using Microsoft.EntityFrameworkCore;
using Passport2.Models;


namespace Passport2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<PassportApplication> PassportApplications { get; set; }
        public DbSet<Residency> Residencies { get; set; }
        public DbSet<ResidencyApplication> ResidencyApplications { get; set;}



    }
}
