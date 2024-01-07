using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Data.Mapping
{
    public class ApplicationMapping : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasOne(a => a.JobSeeker)
                   .WithMany(js => js.Applications)
                   .HasForeignKey(a => a.JobSeekerId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
