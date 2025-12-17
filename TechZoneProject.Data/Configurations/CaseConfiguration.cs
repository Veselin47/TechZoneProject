using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class CaseConfiguration : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.ToTable("Cases");

            builder.Property(c => c.FormFactor).IsRequired().HasMaxLength(20);
            builder.Property(c => c.SupportedFormats).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Color).HasMaxLength(20);
        }
    }
}