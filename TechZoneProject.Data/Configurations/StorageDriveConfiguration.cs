using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class StorageDriveConfiguration : IEntityTypeConfiguration<StorageDrive>
    {
        public void Configure(EntityTypeBuilder<StorageDrive> builder)
        {
            builder.ToTable("StorageDrives");

            builder.Property(s => s.Type).IsRequired().HasMaxLength(20); // NVMe
            builder.Property(s => s.Interface).IsRequired().HasMaxLength(20); // PCIe 4.0
            builder.Property(s => s.FormFactor).IsRequired().HasMaxLength(20); // M.2
        }
    }
}