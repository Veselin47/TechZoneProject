using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class MouseConfiguration : IEntityTypeConfiguration<Mouse>
    {
        public void Configure(EntityTypeBuilder<Mouse> builder)
        {
            builder.ToTable("Mice");

            builder.Property(m => m.SensorType).HasMaxLength(20);
            builder.Property(m => m.ConnectionType).HasMaxLength(20);
            builder.Property(m => m.Color).HasMaxLength(20);
        }
    }
}