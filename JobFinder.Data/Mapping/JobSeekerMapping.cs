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

            builder.HasOne(js => js.File)
                .WithOne(f => f.JobSeeker)
                .HasForeignKey<Entities.Entities.File>(f => f.JobSeekerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
