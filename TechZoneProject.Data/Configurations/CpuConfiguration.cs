using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class CpuConfiguration : IEntityTypeConfiguration<Cpu>
    {
        public void Configure(EntityTypeBuilder<Cpu> builder)
        {
            builder.ToTable("Cpus");

            builder.Property(c => c.Socket).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Cache).HasMaxLength(100);
            builder.Property(c => c.Series).IsRequired().HasMaxLength(50);
        }
    }
}