using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.SeedData
{
    public static class CompanySeedData
    {
        public static void CompanySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                Name = "Acme Corporation",
                Email = "info@acme.com",
                PhoneNumber = "1-800-555-1212",
                Address = "123 Main St, Anytown, CA 12345",
                UserId = 1,
                CreationDate = DateTime.Now,
            },

            new Company
            {
                Id = 2,
                Name = "Globex Corporation",
                Email = "contact@globex.com",
                PhoneNumber = "1-888-555-2323",
                Address = "456 Elm St, Business City, NY 54321",
                CreationDate = DateTime.Now,
                UserId= 2,
            },

            new Company
            {
                Id = 3,
                Name = "Microsoft",
                Email = "contact@microsoft.com",
                PhoneNumber = "1-888-555-2323",
                Address = "456 Elm St, Business City, NY 54321",
                CreationDate = DateTime.Now,
                UserId = 3,
            },

            new Company
            {
                Id = 4,
                Name = "Uber",
                Email = "contact@uber.com",
                PhoneNumber = "1-888-555-2323",
                Address = "456 Elm St, Business City, NY 54321",
                CreationDate = DateTime.Now,
                UserId = 4,
            },

            new Company
            {
                Id = 5,
                Name = "Initech",
                Email = "support@initech.com",
                PhoneNumber = "1-877-555-3434",
                Address = "789 Tech St, Silicon Valley, CA 98765",
                CreationDate = DateTime.Now,
                UserId = 5,
            });
        }

    }
}
