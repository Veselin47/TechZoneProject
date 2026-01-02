using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<ProductTag> ProductTags { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Motherboard> Motherboards { get; set; } = null!;
        public DbSet<Cpu> Cpus { get; set; } = null!;
        public DbSet<Gpu> Gpus { get; set; } = null!;
        public DbSet<Ram> Rams { get; set; } = null!;
        public DbSet<StorageDrive> StorageDrives { get; set; } = null!;
        public DbSet<PowerSupply> PowerSupplies { get; set; } = null!;
        public DbSet<Case> Cases { get; set; } = null!;
        public DbSet<Display> Displays { get; set; } = null!; 
        public DbSet<Keyboard> Keyboards { get; set; } = null!;
        public DbSet<Mouse> Mice { get; set; } = null!;
        public DbSet<ComputerConfiguration> ComputerConfigurations { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<WishlistItem> WishlistItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}