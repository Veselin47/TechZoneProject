using Microsoft.Extensions.DependencyInjection;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Data.Seeding
{
    public static class DbSeeder
    {
        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                if (context.Products.Any())
                {
                    return;
                }

                var brandAsus = new Brand { Name = "ASUS" };
                var brandIntel = new Brand { Name = "Intel" };
                var brandNvidia = new Brand { Name = "NVIDIA" };
                var brandSamsung = new Brand { Name = "Samsung" };
                var brandKingston = new Brand { Name = "Kingston" };

                context.Brands.AddRange(brandAsus, brandIntel, brandNvidia, brandSamsung, brandKingston);
                context.SaveChanges();


                var cpu = new Cpu
                {
                    Name = "Intel Core i9-14900K",
                    Description = "Най-мощният процесор за гейминг.",
                    Price = 1350.00m,
                    ImageUrl = "/images/products/Intel_Core_i9-14900K.jpg",
                    Brand = brandIntel,
                    StockQuantity = 10,
                    IsDeleted = false,

                    WarrantyMonths = 36,
                    Socket = "LGA1700",
                    PhysicalCores = 24,       
                    LogicalCores = 32,
                    BaseFrequencyGhz = 3.2,
                    TurboFrequencyGhz = 6.0,
                    Cache = "36MB Intel Smart Cache",
                    Series = "i9",
                    HasBoxCooler = false
                };

                var gpu = new Gpu
                {
                    Name = "ASUS ROG Strix RTX 4090",
                    Description = "Чудовищна производителност.",
                    Price = 4200.00m,
                    ImageUrl = "/images/products/ASUS_ROG_Strix_RTX_4090.png",
                    Brand = brandAsus,
                    StockQuantity = 3,
                    IsDeleted = false,

                    WarrantyMonths = 36,
                    MemorySizeGb = 24,
                    MemoryType = "GDDR6X",
                    CudaCores = 16384,
                    BusWidthBit = 384,
                    FrequencyMhz = 2640,
                    Connectors = "HDMI 2.1, 3x DP 1.4a"
                };

                var monitor = new Display
                {
                    Name = "Samsung Odyssey G9",
                    Description = "49-инчов извит монитор.",
                    Price = 2899.00m,
                    ImageUrl = "/images/products/Samsung_Odyssey_G9.jpg",
                    Brand = brandSamsung,
                    StockQuantity = 5,
                    IsDeleted = false,

                    WarrantyMonths = 24,
                    ScreenSizeInch = 49,
                    Resolution = "5120x1440",
                    PanelType = "OLED",
                    RefreshRateHz = 240,
                    ResponseTimeMs = 1,
                    IsCurved = true,
                    Ports = "HDMI, DP, USB Hub"
                };

                var ram = new Ram
                {
                    Name = "Kingston FURY Beast 32GB Kit",
                    Description = "DDR5 RGB памет за ентусиасти.",
                    Price = 280.00m,
                    ImageUrl = "/images/products/Kingston_FURY_Beast_32GB.jpg",
                    Brand = brandKingston,
                    StockQuantity = 50,
                    IsDeleted = false,

                    WarrantyMonths = 99, 
                    CapacityGb = 32,
                    Type = "DDR5",
                    SpeedMt = 6000,     
                    Timing = "CL40",
                    IsKit = true,
                    HasRgb = true,
                    HasHeatsink = true,
                    Color = "Black"
                };

                context.Cpus.Add(cpu);
                context.Gpus.Add(gpu);
                context.Displays.Add(monitor);
                context.Rams.Add(ram);

                context.SaveChanges();
            }
        }
    }
}