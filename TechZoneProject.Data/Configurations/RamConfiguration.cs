using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class RamConfiguration : IEntityTypeConfiguration<Ram>
    {
        public void Configure(EntityTypeBuilder<Ram> builder)
        {
            builder.ToTable("Rams");

            builder.Property(r => r.Type).IsRequired().HasMaxLength(10); 
            builder.Property(r => r.Timing).IsRequired().HasMaxLength(10); 
            builder.Property(r => r.Color).HasMaxLength(20);
        }
    }
}