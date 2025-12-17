using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class DisplayConfiguration : IEntityTypeConfiguration<Display>
    {
        public void Configure(EntityTypeBuilder<Display> builder)
        {
            builder.ToTable("Monitors");

            builder.Property(m => m.Resolution).IsRequired().HasMaxLength(20);
            builder.Property(m => m.PanelType).IsRequired().HasMaxLength(10);
            builder.Property(m => m.Ports).HasMaxLength(100);
        }
    }
}