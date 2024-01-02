using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Data.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // implemented in Job Configuration
            // implemented in User Configuration

            builder.HasOne(c => c.CompanyProfilePhoto)
                   .WithOne()
                   .HasForeignKey<Company>(c => c.CompanyProfilePhotoId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
