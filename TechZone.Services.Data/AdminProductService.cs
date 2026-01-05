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

           
        }
        public async Task<IEnumerable<KeyValuePair<string, string>>> GetAllBrandsAsync()
        {
            return await this.dbContext.Brands
                .Select(b => new KeyValuePair<string, string>(b.Id.ToString(), b.Name))
                .ToListAsync();
        }

        //                     CPU
        //===============================================//

        private void MapCpuData(Cpu cpu, AddCpuViewModel model)
        {
           
            MapBaseProductInfo(cpu, model);

            cpu.Socket = model.Socket;
            cpu.Series = model.Series;
            cpu.PhysicalCores = model.PhysicalCores;
            cpu.LogicalCores = model.LogicalCores;
            cpu.BaseFrequencyGhz = model.BaseFrequencyGhz;
            cpu.TurboFrequencyGhz = model.TurboFrequencyGhz;
            cpu.Cache = model.Cache;
            cpu.HasBoxCooler = model.HasBoxCooler;
        }

        public async Task CreateCpuAsync(AddCpuViewModel model)
        {
            var cpu = new Cpu();

            MapCpuData(cpu, model);

            await this.dbContext.Cpus.AddAsync(cpu);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditCpuAsync(int id, AddCpuViewModel model)
        {
            var cpu = await this.dbContext.Cpus.FindAsync(id);
            if (cpu == null) throw new ArgumentException("Invalid ID");

            MapCpuData(cpu, model);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddCpuViewModel> GetCpuForEditAsync(int id)
        {
            var cpu = await this.dbContext.Cpus
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (cpu == null) throw new ArgumentException("Invalid ID");

            return new AddCpuViewModel
            {
                Id = cpu.Id,
                Name = cpu.Name,
                Price = cpu.Price,
                ImageUrl = cpu.ImageUrl,
                Description = cpu.Description,
                StockQuantity = cpu.StockQuantity,
                WarrantyMonths = cpu.WarrantyMonths,
                BrandId = cpu.BrandId,

                Socket = cpu.Socket,
                Series = cpu.Series,
                PhysicalCores = cpu.PhysicalCores,
                LogicalCores = cpu.LogicalCores,
                BaseFrequencyGhz = cpu.BaseFrequencyGhz,
                TurboFrequencyGhz = cpu.TurboFrequencyGhz,
                Cache = cpu.Cache,
                HasBoxCooler = cpu.HasBoxCooler,

                Brands = await GetAllBrandsAsync()
            };
        }
        //===============================================//

        //                     GPU
        //===============================================//

        private void MapGpuData(Gpu gpu, AddGpuViewModel model)
        {
            MapBaseProductInfo(gpu, model);

            gpu.MemorySizeGb = model.MemorySizeGb;
            gpu.MemoryType = model.MemoryType;
            gpu.CudaCores = model.CudaCores;
            gpu.BusWidthBit = model.BusWidthBit;
            gpu.FrequencyMhz = model.FrequencyMhz;
            gpu.Connectors = model.Connectors;
        }

        public async Task CreateGpuAsync(AddGpuViewModel model)
        {
            var gpu = new Gpu();

            MapGpuData(gpu, model);

            await this.dbContext.Gpus.AddAsync(gpu);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditGpuAsync(int id, AddGpuViewModel model)
        {
            var gpu = await this.dbContext.Gpus.FindAsync(id);
            if (gpu == null) throw new ArgumentException("Invalid ID");

            MapGpuData(gpu, model);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddGpuViewModel> GetGpuForEditAsync(int id)
        {
            var gpu = await this.dbContext.Gpus
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (gpu == null) throw new ArgumentException("Invalid ID");

            return new AddGpuViewModel
            {
                Id = gpu.Id,
                Name = gpu.Name,
                Price = gpu.Price,
                ImageUrl = gpu.ImageUrl,
                Description = gpu.Description,
                StockQuantity = gpu.StockQuantity,
                WarrantyMonths = gpu.WarrantyMonths,
                BrandId = gpu.BrandId,

                MemorySizeGb = gpu.MemorySizeGb,
                MemoryType = gpu.MemoryType,
                CudaCores = gpu.CudaCores,
                BusWidthBit = gpu.BusWidthBit,
                FrequencyMhz = gpu.FrequencyMhz,
                Connectors = gpu.Connectors,

                Brands = await GetAllBrandsAsync()
            };
        }
        //===============================================//

        
        private void MapMotherboardData(Motherboard mb, AddMotherboardViewModel model)
        {
            MapBaseProductInfo(mb, model);

            mb.WarrantyMonths = model.WarrantyMonths;

            mb.Socket = model.Socket;
            mb.FormFactor = model.FormFactor;
            mb.Chipset = model.Chipset;
            mb.MemorySlots = model.MemorySlots;
            mb.MemoryType = model.MemoryType;
            mb.HasWifi = model.HasWifi;
        }

        public async Task CreateMotherboardAsync(AddMotherboardViewModel model)
        {
            var motherboard = new Motherboard();

            MapMotherboardData(motherboard, model);

            await this.dbContext.Motherboards.AddAsync(motherboard);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditMotherboardAsync(int id, AddMotherboardViewModel model)
        {
            var motherboard = await this.dbContext.Motherboards.FindAsync(id);
            if (motherboard == null) throw new ArgumentException("Invalid ID");

            MapMotherboardData(motherboard, model);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddMotherboardViewModel> GetMotherboardForEditAsync(int id)
        {
            var mb = await this.dbContext.Motherboards
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (mb == null) throw new ArgumentException("Invalid ID");

            return new AddMotherboardViewModel
            {
                Id = mb.Id,
                Name = mb.Name,
                Price = mb.Price,
                ImageUrl = mb.ImageUrl,
                Description = mb.Description,
                StockQuantity = mb.StockQuantity,
                WarrantyMonths = mb.WarrantyMonths,
                BrandId = mb.BrandId,

                Socket = mb.Socket,
                FormFactor = mb.FormFactor,
                Chipset = mb.Chipset,
                MemorySlots = mb.MemorySlots,
                MemoryType = mb.MemoryType,
                HasWifi = mb.HasWifi,

                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapPowerSupplyData(PowerSupply psu, AddPowerSupplyViewModel model)
        {
            MapBaseProductInfo(psu, model);

            psu.WarrantyMonths = model.WarrantyMonths;

            psu.PowerWatts = model.PowerWatts;
            psu.Certification = model.Certification;
            psu.IsModular = model.IsModular;
            psu.FormFactor = model.FormFactor;
            psu.Standard = model.Standard;
        }

        public async Task CreatePowerSupplyAsync(AddPowerSupplyViewModel model)
        {
            var psu = new PowerSupply();

            MapPowerSupplyData(psu, model);

            await this.dbContext.PowerSupplies.AddAsync(psu);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditPowerSupplyAsync(int id, AddPowerSupplyViewModel model)
        {
            var psu = await this.dbContext.PowerSupplies.FindAsync(id);
            if (psu == null) throw new ArgumentException("Invalid ID");

            MapPowerSupplyData(psu, model);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddPowerSupplyViewModel> GetPowerSupplyForEditAsync(int id)
        {
            var psu = await this.dbContext.PowerSupplies
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (psu == null) throw new ArgumentException("Invalid ID");

            return new AddPowerSupplyViewModel
            {
                Id = psu.Id,
                Name = psu.Name,
                Price = psu.Price,
                ImageUrl = psu.ImageUrl,
                Description = psu.Description,
                StockQuantity = psu.StockQuantity,
                WarrantyMonths = psu.WarrantyMonths,
                BrandId = psu.BrandId,

                PowerWatts = psu.PowerWatts,
                Certification = psu.Certification,
                IsModular = psu.IsModular,
                FormFactor = psu.FormFactor,
                Standard = psu.Standard,

                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapRamData(Ram ram, AddRamViewModel model)
        {
            MapBaseProductInfo(ram, model);

            ram.WarrantyMonths = model.WarrantyMonths;

            ram.CapacityGb = model.CapacityGb;
            ram.Type = model.Type;
            ram.SpeedMt = model.SpeedMt;
            ram.Timing = model.Timing;
            ram.Color = model.Color;
            ram.IsKit = model.IsKit;
            ram.HasRgb = model.HasRgb;
            ram.HasHeatsink = model.HasHeatsink;
        }

        public async Task CreateRamAsync(AddRamViewModel model)
        {
            var ram = new Ram();

            MapRamData(ram, model);

            await this.dbContext.Rams.AddAsync(ram);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditRamAsync(int id, AddRamViewModel model)
        {
            var ram = await this.dbContext.Rams.FindAsync(id);
            if (ram == null) throw new ArgumentException("Invalid ID");

            MapRamData(ram, model);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddRamViewModel> GetRamForEditAsync(int id)
        {
            var ram = await this.dbContext.Rams
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (ram == null) throw new ArgumentException("Invalid ID");

            return new AddRamViewModel
            {
                Id = ram.Id,
                Name = ram.Name,
                Price = ram.Price,
                ImageUrl = ram.ImageUrl,
                Description = ram.Description,
                StockQuantity = ram.StockQuantity,
                WarrantyMonths = ram.WarrantyMonths,
                BrandId = ram.BrandId,

                CapacityGb = ram.CapacityGb,
                Type = ram.Type,
                SpeedMt = ram.SpeedMt,
                Timing = ram.Timing,
                Color = ram.Color,
                IsKit = ram.IsKit,
                HasRgb = ram.HasRgb,
                HasHeatsink = ram.HasHeatsink,

                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapStorageDriveData(StorageDrive drive, AddStorageDriveViewModel model)
        {
            MapBaseProductInfo(drive, model);

            drive.WarrantyMonths = model.WarrantyMonths;

            drive.Type = model.Type;
            drive.Interface = model.Interface;
            drive.FormFactor = model.FormFactor;
            drive.CapacityGb = model.CapacityGb;
            drive.ReadSpeedMb = model.ReadSpeedMb;
            drive.WriteSpeedMb = model.WriteSpeedMb;
        }

        public async Task CreateStorageDriveAsync(AddStorageDriveViewModel model)
        {
            var drive = new StorageDrive();

            MapStorageDriveData(drive, model);

            await this.dbContext.StorageDrives.AddAsync(drive);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditStorageDriveAsync(int id, AddStorageDriveViewModel model)
        {
            var drive = await this.dbContext.StorageDrives.FindAsync(id);
            if (drive == null) throw new ArgumentException("Invalid ID");

            MapStorageDriveData(drive, model);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddStorageDriveViewModel> GetStorageDriveForEditAsync(int id)
        {
            var drive = await this.dbContext.StorageDrives
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (drive == null) throw new ArgumentException("Invalid ID");

            return new AddStorageDriveViewModel
            {
                Id = drive.Id,
                Name = drive.Name,
                Price = drive.Price,
                ImageUrl = drive.ImageUrl,
                Description = drive.Description,
                StockQuantity = drive.StockQuantity,
                WarrantyMonths = drive.WarrantyMonths,
                BrandId = drive.BrandId,

                Type = drive.Type,
                Interface = drive.Interface,
                FormFactor = drive.FormFactor,
                CapacityGb = drive.CapacityGb,
                ReadSpeedMb = drive.ReadSpeedMb,
                WriteSpeedMb = drive.WriteSpeedMb,

                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapCaseData(Case computerCase, AddCaseViewModel model)
        {
            MapBaseProductInfo(computerCase, model);

            computerCase.WarrantyMonths = model.WarrantyMonths;

            computerCase.FormFactor = model.FormFactor;
            computerCase.SupportedFormats = model.SupportedFormats;
            computerCase.HasMeshFront = model.HasMeshFront;
            computerCase.Color = model.Color;
            computerCase.LengthMm = model.LengthMm;
            computerCase.WidthMm = model.WidthMm;
            computerCase.HeightMm = model.HeightMm;
        }

        public async Task CreateCaseAsync(AddCaseViewModel model)
        {
            var computerCase = new Case();

            MapCaseData(computerCase, model);

            await this.dbContext.Cases.AddAsync(computerCase);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditCaseAsync(int id, AddCaseViewModel model)
        {
            var computerCase = await this.dbContext.Cases.FindAsync(id);
            if (computerCase == null) throw new ArgumentException("Invalid ID");

            MapCaseData(computerCase, model);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddCaseViewModel> GetCaseForEditAsync(int id)
        {
            var computerCase = await this.dbContext.Cases
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (computerCase == null) throw new ArgumentException("Invalid ID");

            return new AddCaseViewModel
            {
                Id = computerCase.Id,
                Name = computerCase.Name,
                Price = computerCase.Price,
                ImageUrl = computerCase.ImageUrl,
                Description = computerCase.Description,
                StockQuantity = computerCase.StockQuantity,
                WarrantyMonths = computerCase.WarrantyMonths,
                BrandId = computerCase.BrandId,

                FormFactor = computerCase.FormFactor,
                SupportedFormats = computerCase.SupportedFormats,
                HasMeshFront = computerCase.HasMeshFront,
                Color = computerCase.Color,
                LengthMm = computerCase.LengthMm,
                WidthMm = computerCase.WidthMm,
                HeightMm = computerCase.HeightMm,

                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapDisplayData(Display display, AddDisplayViewModel model)
        {
            MapBaseProductInfo(display, model);

            display.WarrantyMonths = model.WarrantyMonths;

            display.ScreenSizeInch = model.ScreenSizeInch;
            display.Resolution = model.Resolution;
            display.RefreshRateHz = model.RefreshRateHz;
            display.PanelType = model.PanelType;
            display.ResponseTimeMs = model.ResponseTimeMs;
            display.Ports = model.Ports;
            display.IsCurved = model.IsCurved;
        }

        public async Task CreateDisplayAsync(AddDisplayViewModel model)
        {
            var display = new Display();

            MapDisplayData(display, model);

            await this.dbContext.Displays.AddAsync(display);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditDisplayAsync(int id, AddDisplayViewModel model)
        {
            var display = await this.dbContext.Displays.FindAsync(id);
            if (display == null) throw new ArgumentException("Invalid ID");

            MapDisplayData(display, model);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddDisplayViewModel> GetDisplayForEditAsync(int id)
        {
            var display = await this.dbContext.Displays
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (display == null) throw new ArgumentException("Invalid ID");

            return new AddDisplayViewModel
            {
                Id = display.Id,
                Name = display.Name,
                Price = display.Price,
                ImageUrl = display.ImageUrl,
                Description = display.Description,
                StockQuantity = display.StockQuantity,
                WarrantyMonths = display.WarrantyMonths,
                BrandId = display.BrandId,

                ScreenSizeInch = display.ScreenSizeInch,
                Resolution = display.Resolution,
                RefreshRateHz = display.RefreshRateHz,
                PanelType = display.PanelType,
                ResponseTimeMs = display.ResponseTimeMs,
                Ports = display.Ports,
                IsCurved = display.IsCurved,

                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapKeyboardData(Keyboard keyboard, AddKeyboardViewModel model)
        {
            MapBaseProductInfo(keyboard, model);
            keyboard.WarrantyMonths = model.WarrantyMonths;

            keyboard.SwitchType = model.SwitchType;
            keyboard.Layout = model.Layout;
            keyboard.SizePercentage = model.SizePercentage;
            keyboard.ConnectionType = model.ConnectionType;
            keyboard.HasRgb = model.HasRgb;
        }

        public async Task CreateKeyboardAsync(AddKeyboardViewModel model)
        {
            var keyboard = new Keyboard();
            MapKeyboardData(keyboard, model);

            await this.dbContext.Keyboards.AddAsync(keyboard);
            await this.dbContext.SaveChangesAsync();
        }

        
        public async Task EditKeyboardAsync(int id, AddKeyboardViewModel model)
        {
            var keyboard = await this.dbContext.Keyboards.FindAsync(id);
            if (keyboard == null) throw new ArgumentException("Invalid ID");

            MapKeyboardData(keyboard, model); 
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddKeyboardViewModel> GetKeyboardForEditAsync(int id)
        {
            var kb = await this.dbContext.Keyboards
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (kb == null) throw new ArgumentException("Invalid ID");

            return new AddKeyboardViewModel
            {
                Id = kb.Id,
                Name = kb.Name,
                Price = kb.Price,
                ImageUrl = kb.ImageUrl,
                Description = kb.Description,
                StockQuantity = kb.StockQuantity,
                WarrantyMonths = kb.WarrantyMonths,
                BrandId = kb.BrandId,

                SwitchType = kb.SwitchType,
                Layout = kb.Layout,
                SizePercentage = kb.SizePercentage,
                ConnectionType = kb.ConnectionType,
                HasRgb = kb.HasRgb,

                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapMouseData(Mouse mouse, AddMouseViewModel model)
        {
            MapBaseProductInfo(mouse, model);
            mouse.WarrantyMonths = model.WarrantyMonths;

            mouse.Dpi = model.Dpi;
            mouse.ConnectionType = model.ConnectionType;
            mouse.ButtonsCount = model.ButtonsCount;
            mouse.Color = model.Color;
            mouse.SensorType = model.SensorType;
            mouse.WeightGrams = model.WeightGrams;
        }

        public async Task CreateMouseAsync(AddMouseViewModel model)
        {
            var mouse = new Mouse();
            MapMouseData(mouse, model); 

            await this.dbContext.Mice.AddAsync(mouse);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditMouseAsync(int id, AddMouseViewModel model)
        {
            var mouse = await this.dbContext.Mice.FindAsync(id);
            if (mouse == null) throw new ArgumentException("Invalid ID");

            MapMouseData(mouse, model); 

            await this.dbContext.SaveChangesAsync();
        }

    
        public async Task<AddMouseViewModel> GetMouseForEditAsync(int id)
        {
            var mouse = await this.dbContext.Mice
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (mouse == null) throw new ArgumentException("Invalid ID");

            return new AddMouseViewModel
            {
                Id = mouse.Id,
                Name = mouse.Name,
                Price = mouse.Price,
                ImageUrl = mouse.ImageUrl,
                Description = mouse.Description,
                StockQuantity = mouse.StockQuantity,
                WarrantyMonths = mouse.WarrantyMonths,
                BrandId = mouse.BrandId,

                Dpi = mouse.Dpi,
                ConnectionType = mouse.ConnectionType,
                ButtonsCount = mouse.ButtonsCount,
                Color = mouse.Color,
                SensorType = mouse.SensorType,
                WeightGrams = mouse.WeightGrams,

                Brands = await GetAllBrandsAsync()
            };
        }

        // !!!! Край на методите за продукти !!!


        public async Task<IEnumerable<ProductAllViewModel>> GetAllProductsAsync()
        {
            return await this.dbContext.Products
                .Where(p => !p.IsDeleted) 
                .OrderByDescending(p => p.CreatedOn)
                .Select(p => new ProductAllViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    Brand = p.Brand.Name,
                    ProductType = p.GetType().Name
                })
                .ToListAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await this.dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.IsDeleted = true;
                product.DeletedOn = DateTime.UtcNow;
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
