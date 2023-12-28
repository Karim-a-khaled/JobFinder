using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Data.Mapping
{
    public class JobMapping : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasOne(j => j.Company)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(j => j.Applications)
                .WithOne(c => c.Job)
                .HasForeignKey(j => j.JobId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
