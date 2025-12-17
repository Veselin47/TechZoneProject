using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // TPT Strategy: Тази таблица ще пази общите данни
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(2048);

            // Валута
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            // Soft Delete
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            //builder.HasQueryFilter(p => !p.IsDeleted);
            builder.Property(p => p.StockQuantity)
           .IsRequired()
           .HasDefaultValue(0);

            // Връзка с Brand
            builder.HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}