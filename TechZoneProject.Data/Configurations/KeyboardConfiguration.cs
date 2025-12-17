using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class KeyboardConfiguration : IEntityTypeConfiguration<Keyboard>
    {
        public void Configure(EntityTypeBuilder<Keyboard> builder)
        {
            builder.ToTable("Keyboards");

            builder.Property(k => k.SwitchType).HasMaxLength(20);
            builder.Property(k => k.Layout).HasMaxLength(10);
            builder.Property(k => k.SizePercentage).HasMaxLength(10);
            builder.Property(k => k.ConnectionType).HasMaxLength(20);
        }
    }
}