using JobFinder.Entities.Entities;
using JobFinder.Entities.Entities.UserManagement;
using JobFinder.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data.SeedData
{
    public static class RoleSeedData
    {
        public static void RolesSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = (int)RoleEnum.JobSeeker,
                    ModificationDate = DateTime.Now.Date,
                    Name = "JobSeeker"
                },
                new Role
                {
                    Id = (int)RoleEnum.Employer,
                    ModificationDate = DateTime.Now.Date,
                    Name = "Employer"
                });
        }
    }
}
