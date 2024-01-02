using JobFinder.Data.SeedData;
using JobFinder.Entities.Entities;
using JobFinder.Entities.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Entities.Entities.File> Files{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.RolesSeedData();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }

}
