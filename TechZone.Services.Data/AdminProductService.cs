using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZone.Services.Data.Interfaces;
using TechZoneProject.Data;
using TechZoneProject.Data.Models;
using TechZone.Web.ViewModels.Admin.Models;

namespace TechZone.Services.Data
{
    public class AdminProductService : IAdminProductService
    {
        private readonly ApplicationDbContext dbContext;

        public AdminProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private void MapBaseProductInfo(Product product, ProductInputModel model)
        {
            product.Name = model.Name;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.Description = model.Description;
            product.BrandId = model.BrandId;
            product.StockQuantity = model.StockQuantity;

            // Тези се попълват автоматично от BaseEntity конструктора:
            // product.IsDeleted = false;
            // product.CreatedOn = DateTime.UtcNow;
        }
        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllBrandsAsync()
        {
            return await this.dbContext.Brands
                .Select(b => new KeyValuePair<string, string>(b.Id.ToString(), b.Name))
                .ToListAsync();
        }

        public async Task CreateCpuAsync(AddCpuViewModel model)
        {
            Cpu cpu = new Cpu();

            MapBaseProductInfo(cpu, model);
            cpu.WarrantyMonths = model.WarrantyMonths;
            cpu.Socket = model.Socket;
            cpu.Series = model.Series;
            cpu.PhysicalCores = model.PhysicalCores;
            cpu.LogicalCores = model.LogicalCores;
            cpu.BaseFrequencyGhz = model.BaseFrequencyGhz;
            cpu.TurboFrequencyGhz = model.TurboFrequencyGhz;
            cpu.Cache = model.Cache;
            cpu.HasBoxCooler = model.HasBoxCooler;

            await this.dbContext.Cpus.AddAsync(cpu);
            await this.dbContext.SaveChangesAsync();

        }
        public async Task CreateGpuAsync(AddGpuViewModel model)
        {
            var gpu = new Gpu();

            MapBaseProductInfo(gpu, model);

            gpu.WarrantyMonths = model.WarrantyMonths;
            gpu.MemorySizeGb = model.MemorySizeGb;
            gpu.MemoryType = model.MemoryType;
            gpu.CudaCores = model.CudaCores;
            gpu.BusWidthBit = model.BusWidthBit;
            gpu.FrequencyMhz = model.FrequencyMhz;
            gpu.Connectors = model.Connectors;

            await this.dbContext.Gpus.AddAsync(gpu);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateMotherboardAsync(AddMotherboardViewModel model)
        {
            var motherboard = new Motherboard();
            MapBaseProductInfo(motherboard, model);
            motherboard.Socket = model.Socket;
            motherboard.FormFactor = model.FormFactor;
            motherboard.Chipset = model.Chipset;
            motherboard.MemoryType = model.MemoryType;
            motherboard.MemorySlots = model.MemorySlots;
            motherboard.HasWifi = model.HasWifi;
            motherboard.WarrantyMonths = model.WarrantyMonths;

            await this.dbContext.Motherboards.AddAsync(motherboard);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task CreatePowerSupplyAsync(AddPowerSupplyViewModel model)
        {
            var powerSupply = new PowerSupply();
            MapBaseProductInfo(powerSupply, model);
            powerSupply.WarrantyMonths = model.WarrantyMonths;
            powerSupply.PowerWatts = model.PowerWatts;
            powerSupply.Certification = model.Certification;
            powerSupply.IsModular = model.IsModular;
            powerSupply.Standard = model.Standard;
            await this.dbContext.PowerSupplies.AddAsync(powerSupply);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task CreateRamAsync(AddRamViewModel model)
        {
            var ram = new Ram();
            MapBaseProductInfo(ram, model);
            ram.CapacityGb = model.CapacityGb;
            ram.Type = model.Type;
            ram.SpeedMt = model.SpeedMt;
            ram.Color = model.Color;
            ram.Timing = model.Timing;
            ram.IsKit = model.IsKit;
            ram.HasRgb = model.HasRgb;
            ram.HasHeatsink = model.HasHeatsink;
            await this.dbContext.Rams.AddAsync(ram);
            await this.dbContext.SaveChangesAsync();

        }
        public async Task CreateStorageDriveAsync(AddStorageDriveViewModel model)
        {
            var storageDrive = new StorageDrive();
            MapBaseProductInfo(storageDrive, model);
            storageDrive.Type = model.Type;
            storageDrive.Interface = model.Interface;
            storageDrive.FormFactor = model.FormFactor;
            storageDrive.CapacityGb = model.CapacityGb;
            storageDrive.ReadSpeedMb = model.ReadSpeedMb;
            storageDrive.WriteSpeedMb = model.WriteSpeedMb;
            await this.dbContext.StorageDrives.AddAsync(storageDrive);
            await this.dbContext.StorageDrives.AddAsync(storageDrive);
        }
        public async Task CreateCaseAsync(AddCaseViewModel model)
        {
            var computerCase = new Case();
            MapBaseProductInfo(computerCase, model);
            computerCase.FormFactor = model.FormFactor;
            computerCase.HasMeshFront = model.HasMeshFront;
            computerCase.Color = model.Color;
            computerCase.SupportedFormats = model.SupportedFormats;
            computerCase.LengthMm = model.LengthMm;
            computerCase.WidthMm = model.WidthMm;
            computerCase.HeightMm = model.HeightMm;
            await this.dbContext.Cases.AddAsync(computerCase);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task CreateDisplayAsync(AddDisplayViewModel model) 
        {
            var display = new Display();
            MapBaseProductInfo(display, model);
            display.ScreenSizeInch = model.ScreenSizeInch;
            display.Resolution = model.Resolution;
            display.RefreshRateHz = model.RefreshRateHz;
            display.PanelType = model.PanelType;
            display.ResponseTimeMs = model.ResponseTimeMs;
            display.Ports = model.Ports;
            display.IsCurved = model.IsCurved;
            await this.dbContext.Displays.AddAsync(display);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task CreateKeyboardAsync(AddKeyboardViewModel model)
        {
            var keyboard = new Keyboard();
            MapBaseProductInfo(keyboard, model);
            keyboard.SwitchType = model.SwitchType;
            keyboard.Layout = model.Layout;
            keyboard.SizePercentage = model.SizePercentage;
            keyboard.ConnectionType = model.ConnectionType;
            keyboard.HasRgb = model.HasRgb;
            await this.dbContext.Keyboards.AddAsync(keyboard);
            await this.dbContext.SaveChangesAsync();
        }
        public async Task CreateMouseAsync(AddMouseViewModel model)
        { 
            var mouse = new Mouse();
            MapBaseProductInfo(mouse, model);
            mouse.Dpi = model.Dpi;
            mouse.ConnectionType = model.ConnectionType;
            mouse.ButtonsCount = model.ButtonsCount;
            mouse.Color = model.Color;
            mouse.SensorType = model.SensorType;
            mouse.WeightGrams = model.WeightGrams;
            await this.dbContext.Mice.AddAsync(mouse);
            await this.dbContext.SaveChangesAsync();
        }

    }
}
