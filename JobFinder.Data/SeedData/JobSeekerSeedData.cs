using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.SeedData
{
    public static class JobSeekerSeedData
    {
        public static void JobSeekerSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobSeeker>().HasData(
              new JobSeeker
              {
                  Id = 1,
                  IsFresh = false,
                  Name = "John Doe",
                  Email = "john.doe@example.com",
                  YearsOfExperience = 5,
                  UserId = 6,
                  CreationDate = DateTime.Now,
              },

              new JobSeeker
              {
                  Id = 2,
                  IsFresh = true,
                  Name = "Jane Smith",
                  Email = "jane.smith@example.com",
                  YearsOfExperience = 0,
                  UserId = 7,
                  CreationDate = DateTime.Now,
              },

              new JobSeeker
              {
                  Id = 3,
                  IsFresh = false,
                  Name = "Bob Johnson",
                  Email = "bob.johnson@example.com",
                  YearsOfExperience = 7,
                  UserId = 8,
                  CreationDate = DateTime.Now,
              },

              new JobSeeker
              {
                  Id = 4,
                  IsFresh = true,
                  Name = "Alice Williams",
                  Email = "alice.williams@example.com",
                  YearsOfExperience = 0,
                  UserId = 9,
                  CreationDate = DateTime.Now,
              },

              new JobSeeker
              {
                  Id = 5,
                  IsFresh = true,
                  Name = "Random",
                  Email = "random@example.com",
                  YearsOfExperience = 0,
                  UserId = 10,
                  CreationDate = DateTime.Now,
              });
        }
    }
}
