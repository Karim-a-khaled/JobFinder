using JobFinder.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobFinder.Data.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        // implemented in Apllication Configuration
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            // implemented in Job Configuration
            // implemented in User Configuration
        }
    }
}
