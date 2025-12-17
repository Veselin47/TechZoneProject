using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class ComputerConfigurationConfiguration : IEntityTypeConfiguration<ComputerConfiguration>
    {
        public void Configure(EntityTypeBuilder<ComputerConfiguration> builder)
        {
            builder.ToTable("ComputerConfigurations");

            builder.Property(c => c.CpuModel).IsRequired().HasMaxLength(100);
            builder.Property(c => c.GpuModel).IsRequired().HasMaxLength(100);
            builder.Property(c => c.RamAmount).IsRequired().HasMaxLength(100);
            builder.Property(c => c.SsdAmount).IsRequired().HasMaxLength(100);
        }
    }
}