using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class PowerSupplyConfiguration : IEntityTypeConfiguration<PowerSupply>
    {
        public void Configure(EntityTypeBuilder<PowerSupply> builder)
        {
            builder.ToTable("PowerSupplies");

            builder.Property(ps => ps.Certification).HasMaxLength(30);
            builder.Property(ps => ps.FormFactor).HasMaxLength(20);
            builder.Property(ps => ps.Standard).HasMaxLength(20);
        }
    }
}