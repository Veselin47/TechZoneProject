using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class GpuConfiguration : IEntityTypeConfiguration<Gpu>
    {
        public void Configure(EntityTypeBuilder<Gpu> builder)
        {
            builder.ToTable("Gpus");

            builder.Property(g => g.MemoryType).IsRequired().HasMaxLength(10);
            builder.Property(g => g.Connectors).IsRequired().HasMaxLength(100);
        }
    }
}