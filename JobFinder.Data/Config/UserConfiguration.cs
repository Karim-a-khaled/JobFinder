using JobFinder.Entities.Entities.UserManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using JobFinder.Entities.Entities;

namespace JobFinder.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {


        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(b => b.Email).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Password).HasMaxLength(200).IsRequired();
            builder.HasIndex(b => b.Email).IsUnique();

            // imlemented in UserRole Configuration

            builder.HasOne(u => u.JobSeeker)
                .WithOne(js => js.User)
                .HasForeignKey<JobSeeker>(js => js.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.Company)
                .WithOne(js => js.User)
                .HasForeignKey<Company>(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
