using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class MotherboardConfiguration : IEntityTypeConfiguration<Motherboard>
    {
        public void Configure(EntityTypeBuilder<Motherboard> builder)
        {
            builder.ToTable("Motherboards");

            builder.Property(m => m.Socket).IsRequired().HasMaxLength(20);
            builder.Property(m => m.FormFactor).IsRequired().HasMaxLength(20);
            builder.Property(m => m.Chipset).IsRequired().HasMaxLength(20);
            builder.Property(m => m.MemoryType).IsRequired().HasMaxLength(10);
        }
    }
}