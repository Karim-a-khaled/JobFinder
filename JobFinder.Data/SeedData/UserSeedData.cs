using JobFinder.Entities.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Data.SeedData
{
    public static class UserSeedData
    {
        public static void UserSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User { Email = "info@acme.com", Password = "password", isCompany = true, Id = 1, CreationDate = DateTime.Now },
                    new User { Email = "contact@globex.com", Password = "password", isCompany = true, Id = 2, CreationDate = DateTime.Now },
                    new User { Email = "contact@microsoft.com", Password = "password", isCompany = true, Id = 3, CreationDate = DateTime.Now },
                    new User { Email = "contact@uber.com", Password = "password", isCompany = true, Id = 4, CreationDate = DateTime.Now },
                    new User { Email = "support@initech.com", Password = "password", isCompany = true, Id = 5, CreationDate = DateTime.Now },
                    new User { Email = "john.doe@example.com", Password = "password", isCompany = false, Id = 6, CreationDate = DateTime.Now },
                    new User { Email = "jane.smith@example.com", Password = "password", isCompany = false, Id = 7, CreationDate = DateTime.Now },
                    new User { Email = "bob.johnson@example.com", Password = "password", isCompany = false, Id = 8, CreationDate = DateTime.Now },
                    new User { Email = "alice.williams@example.com", Password = "password", isCompany = false, Id = 9, CreationDate = DateTime.Now },
                    new User { Email = "random@example.com", Password = "password", isCompany = false, Id = 10, CreationDate = DateTime.Now }
                );
        }
    }
}
