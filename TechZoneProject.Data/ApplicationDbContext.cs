using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data
{
    // 1. Наследяваме IdentityDbContext с нашия разширен потребител (ApplicationUser)
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // --- 2. Основни номенклатури ---
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<ProductTag> ProductTags { get; set; } = null!;

        // --- 3. Продукти (TPT Йерархия) ---
        // Това е базовата таблица. Чрез нея можеш да търсиш във всички продукти едновременно.
        public DbSet<Product> Products { get; set; } = null!;

        // Специфични таблици за всеки тип хардуер
        public DbSet<Motherboard> Motherboards { get; set; } = null!;
        public DbSet<Cpu> Cpus { get; set; } = null!;
        public DbSet<Gpu> Gpus { get; set; } = null!;
        public DbSet<Ram> Rams { get; set; } = null!;
        public DbSet<StorageDrive> StorageDrives { get; set; } = null!;
        public DbSet<PowerSupply> PowerSupplies { get; set; } = null!;
        public DbSet<Case> Cases { get; set; } = null!;
        public DbSet<Display> Displays { get; set; } = null!; // Тук вече е Display, не Monitor
        public DbSet<Keyboard> Keyboards { get; set; } = null!;
        public DbSet<Mouse> Mice { get; set; } = null!;
        public DbSet<ComputerConfiguration> ComputerConfigurations { get; set; } = null!;

        // --- 4. Търговска част ---
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<WishlistItem> WishlistItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // ВАЖНО: Този ред е критичен за Identity системата!
            // Ако го изтриеш, Login/Register няма да работят.
            base.OnModelCreating(builder);

            // Тази магия намира всички Configuration файлове в текущия проект
            // и ги прилага автоматично. Така кодът тук остава чист.
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}