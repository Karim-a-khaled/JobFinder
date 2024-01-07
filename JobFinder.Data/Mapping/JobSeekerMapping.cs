using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Data.Mapping
{
    public class JobSeekerMapping : IEntityTypeConfiguration<JobSeeker>
    {
        // implemented in Apllication Configuration

        public void Configure(EntityTypeBuilder<JobSeeker> builder) 
        {
            // implemented in Application Configuration
            // implemented in User Configuration

            builder.HasOne(js => js.JobSeekerCv)
                   .WithOne()
                   .HasForeignKey<JobSeeker>(js => js.JobSeekerCvId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(js => js.JobSeekerProfilePicture)
                   .WithOne()
                   .HasForeignKey<JobSeeker>(js => js.JobSeekerProfilePictureId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
