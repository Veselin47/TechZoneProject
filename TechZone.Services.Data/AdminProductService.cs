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

        //                     CPU
        //===============================================//

        private void MapCpuData(Cpu cpu, AddCpuViewModel model)
        {
            // Общите неща (използваме помощника, който вече имаш или го добавяме тук)
            // Ако нямаш MapBaseProductInfo, просто ги напиши тук:
            MapBaseProductInfo(cpu, model);

            // Специфичните за CPU
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

            // ЕДИН РЕД върши всичко!
            MapCpuData(cpu, model);

            await this.dbContext.Cpus.AddAsync(cpu);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditCpuAsync(int id, AddCpuViewModel model)
        {
            var cpu = await this.dbContext.Cpus.FindAsync(id);
            if (cpu == null) throw new ArgumentException("Invalid ID");

            // СЪЩИЯТ РЕД върши всичко и тук!
            MapCpuData(cpu, model);

            // Няма AddAsync, само Save, защото EF Core следи промените
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
            // Попълва общите неща (Име, Цена, Марка, Гаранция...)
            MapBaseProductInfo(gpu, model);

            // Попълва специфичните за GPU
            gpu.MemorySizeGb = model.MemorySizeGb;
            gpu.MemoryType = model.MemoryType;
            gpu.CudaCores = model.CudaCores;
            gpu.BusWidthBit = model.BusWidthBit;
            gpu.FrequencyMhz = model.FrequencyMhz;
            gpu.Connectors = model.Connectors;
        }

        // 2. Създаване (CREATE)
        public async Task CreateGpuAsync(AddGpuViewModel model)
        {
            var gpu = new Gpu();

            // Използваме помощния метод
            MapGpuData(gpu, model);

            await this.dbContext.Gpus.AddAsync(gpu);
            await this.dbContext.SaveChangesAsync();
        }

        // 3. Редактиране (EDIT)
        public async Task EditGpuAsync(int id, AddGpuViewModel model)
        {
            var gpu = await this.dbContext.Gpus.FindAsync(id);
            if (gpu == null) throw new ArgumentException("Invalid ID");

            // Използваме същия помощен метод
            MapGpuData(gpu, model);

            await this.dbContext.SaveChangesAsync();
        }

        // 4. Взимане на данни за формата (GET)
        public async Task<AddGpuViewModel> GetGpuForEditAsync(int id)
        {
            var gpu = await this.dbContext.Gpus
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (gpu == null) throw new ArgumentException("Invalid ID");

            return new AddGpuViewModel
            {
                // Общи данни
                Id = gpu.Id,
                Name = gpu.Name,
                Price = gpu.Price,
                ImageUrl = gpu.ImageUrl,
                Description = gpu.Description,
                StockQuantity = gpu.StockQuantity,
                WarrantyMonths = gpu.WarrantyMonths,
                BrandId = gpu.BrandId,

                // Специфични за GPU
                MemorySizeGb = gpu.MemorySizeGb,
                MemoryType = gpu.MemoryType,
                CudaCores = gpu.CudaCores,
                BusWidthBit = gpu.BusWidthBit,
                FrequencyMhz = gpu.FrequencyMhz,
                Connectors = gpu.Connectors,

                // Зареждаме марките за падащото меню
                Brands = await GetAllBrandsAsync()
            };
        }
        //===============================================//

        // 1. Помощен метод (Private)
        private void MapMotherboardData(Motherboard mb, AddMotherboardViewModel model)
        {
            // Попълва общите неща (Име, Цена, Марка, Снимка, Описание...)
            MapBaseProductInfo(mb, model);

            // Гаранцията (ако MapBaseProductInfo не я попълва автоматично, остави я тук)
            mb.WarrantyMonths = model.WarrantyMonths;

            // Специфични за Motherboard
            mb.Socket = model.Socket;
            mb.FormFactor = model.FormFactor;
            mb.Chipset = model.Chipset;
            mb.MemorySlots = model.MemorySlots;
            mb.MemoryType = model.MemoryType;
            mb.HasWifi = model.HasWifi;
        }

        // 2. Създаване (CREATE)
        public async Task CreateMotherboardAsync(AddMotherboardViewModel model)
        {
            var motherboard = new Motherboard();

            // Използваме помощния метод
            MapMotherboardData(motherboard, model);

            await this.dbContext.Motherboards.AddAsync(motherboard);
            await this.dbContext.SaveChangesAsync();
        }

        // 3. Редактиране (EDIT)
        public async Task EditMotherboardAsync(int id, AddMotherboardViewModel model)
        {
            var motherboard = await this.dbContext.Motherboards.FindAsync(id);
            if (motherboard == null) throw new ArgumentException("Invalid ID");

            // Използваме същия помощен метод
            MapMotherboardData(motherboard, model);

            await this.dbContext.SaveChangesAsync();
        }

        // 4. Взимане на данни за формата (GET)
        public async Task<AddMotherboardViewModel> GetMotherboardForEditAsync(int id)
        {
            var mb = await this.dbContext.Motherboards
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (mb == null) throw new ArgumentException("Invalid ID");

            return new AddMotherboardViewModel
            {
                // Общи данни
                Id = mb.Id,
                Name = mb.Name,
                Price = mb.Price,
                ImageUrl = mb.ImageUrl,
                Description = mb.Description,
                StockQuantity = mb.StockQuantity,
                WarrantyMonths = mb.WarrantyMonths,
                BrandId = mb.BrandId,

                // Специфични за Motherboard
                Socket = mb.Socket,
                FormFactor = mb.FormFactor,
                Chipset = mb.Chipset,
                MemorySlots = mb.MemorySlots,
                MemoryType = mb.MemoryType,
                HasWifi = mb.HasWifi,

                // Зареждаме марките за падащото меню
                Brands = await GetAllBrandsAsync()
            };
        }
        // 1. Помощен метод (Private)
        private void MapPowerSupplyData(PowerSupply psu, AddPowerSupplyViewModel model)
        {
            // Попълва общите неща (Име, Цена, Марка...)
            MapBaseProductInfo(psu, model);

            // Гаранцията
            psu.WarrantyMonths = model.WarrantyMonths;

            // Специфични за PSU
            psu.PowerWatts = model.PowerWatts;
            psu.Certification = model.Certification;
            psu.IsModular = model.IsModular;
            psu.FormFactor = model.FormFactor;
            psu.Standard = model.Standard;
        }

        // 2. Създаване (CREATE)
        public async Task CreatePowerSupplyAsync(AddPowerSupplyViewModel model)
        {
            var psu = new PowerSupply();

            // Използваме помощния метод
            MapPowerSupplyData(psu, model);

            await this.dbContext.PowerSupplies.AddAsync(psu);
            await this.dbContext.SaveChangesAsync();
        }

        // 3. Редактиране (EDIT)
        public async Task EditPowerSupplyAsync(int id, AddPowerSupplyViewModel model)
        {
            var psu = await this.dbContext.PowerSupplies.FindAsync(id);
            if (psu == null) throw new ArgumentException("Invalid ID");

            // Използваме същия помощен метод
            MapPowerSupplyData(psu, model);

            await this.dbContext.SaveChangesAsync();
        }

        // 4. Взимане на данни за формата (GET)
        public async Task<AddPowerSupplyViewModel> GetPowerSupplyForEditAsync(int id)
        {
            var psu = await this.dbContext.PowerSupplies
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (psu == null) throw new ArgumentException("Invalid ID");

            return new AddPowerSupplyViewModel
            {
                // Общи данни
                Id = psu.Id,
                Name = psu.Name,
                Price = psu.Price,
                ImageUrl = psu.ImageUrl,
                Description = psu.Description,
                StockQuantity = psu.StockQuantity,
                WarrantyMonths = psu.WarrantyMonths,
                BrandId = psu.BrandId,

                // Специфични за PSU
                PowerWatts = psu.PowerWatts,
                Certification = psu.Certification,
                IsModular = psu.IsModular,
                FormFactor = psu.FormFactor,
                Standard = psu.Standard,

                // Зареждаме марките за падащото меню
                Brands = await GetAllBrandsAsync()
            };
        }
        // 1. Помощен метод (Private)
        private void MapRamData(Ram ram, AddRamViewModel model)
        {
            // Попълва общите неща
            MapBaseProductInfo(ram, model);

            // Гаранцията
            ram.WarrantyMonths = model.WarrantyMonths;

            // Специфични за RAM
            ram.CapacityGb = model.CapacityGb;
            ram.Type = model.Type;
            ram.SpeedMt = model.SpeedMt;
            ram.Timing = model.Timing;
            ram.Color = model.Color;
            ram.IsKit = model.IsKit;
            ram.HasRgb = model.HasRgb;
            ram.HasHeatsink = model.HasHeatsink;
        }

        // 2. Създаване (CREATE)
        public async Task CreateRamAsync(AddRamViewModel model)
        {
            var ram = new Ram();

            // Използваме помощния метод
            MapRamData(ram, model);

            await this.dbContext.Rams.AddAsync(ram);
            await this.dbContext.SaveChangesAsync();
        }

        // 3. Редактиране (EDIT)
        public async Task EditRamAsync(int id, AddRamViewModel model)
        {
            var ram = await this.dbContext.Rams.FindAsync(id);
            if (ram == null) throw new ArgumentException("Invalid ID");

            // Използваме същия помощен метод
            MapRamData(ram, model);

            await this.dbContext.SaveChangesAsync();
        }

        // 4. Взимане на данни за формата (GET)
        public async Task<AddRamViewModel> GetRamForEditAsync(int id)
        {
            var ram = await this.dbContext.Rams
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (ram == null) throw new ArgumentException("Invalid ID");

            return new AddRamViewModel
            {
                // Общи данни
                Id = ram.Id,
                Name = ram.Name,
                Price = ram.Price,
                ImageUrl = ram.ImageUrl,
                Description = ram.Description,
                StockQuantity = ram.StockQuantity,
                WarrantyMonths = ram.WarrantyMonths,
                BrandId = ram.BrandId,

                // Специфични за RAM
                CapacityGb = ram.CapacityGb,
                Type = ram.Type,
                SpeedMt = ram.SpeedMt,
                Timing = ram.Timing,
                Color = ram.Color,
                IsKit = ram.IsKit,
                HasRgb = ram.HasRgb,
                HasHeatsink = ram.HasHeatsink,

                // Зареждаме марките за падащото меню
                Brands = await GetAllBrandsAsync()
            };
        }
        // 1. Помощен метод (Private)
        private void MapStorageDriveData(StorageDrive drive, AddStorageDriveViewModel model)
        {
            // Попълва общите неща
            MapBaseProductInfo(drive, model);

            // Гаранцията
            drive.WarrantyMonths = model.WarrantyMonths;

            // Специфични за Storage
            drive.Type = model.Type;
            drive.Interface = model.Interface;
            drive.FormFactor = model.FormFactor;
            drive.CapacityGb = model.CapacityGb;
            drive.ReadSpeedMb = model.ReadSpeedMb;
            drive.WriteSpeedMb = model.WriteSpeedMb;
        }

        // 2. Създаване (CREATE)
        public async Task CreateStorageDriveAsync(AddStorageDriveViewModel model)
        {
            var drive = new StorageDrive();

            // Използваме помощния метод
            MapStorageDriveData(drive, model);

            await this.dbContext.StorageDrives.AddAsync(drive);
            await this.dbContext.SaveChangesAsync();
        }

        // 3. Редактиране (EDIT)
        public async Task EditStorageDriveAsync(int id, AddStorageDriveViewModel model)
        {
            var drive = await this.dbContext.StorageDrives.FindAsync(id);
            if (drive == null) throw new ArgumentException("Invalid ID");

            // Използваме същия помощен метод
            MapStorageDriveData(drive, model);

            await this.dbContext.SaveChangesAsync();
        }

        // 4. Взимане на данни за формата (GET)
        public async Task<AddStorageDriveViewModel> GetStorageDriveForEditAsync(int id)
        {
            var drive = await this.dbContext.StorageDrives
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (drive == null) throw new ArgumentException("Invalid ID");

            return new AddStorageDriveViewModel
            {
                // Общи данни
                Id = drive.Id,
                Name = drive.Name,
                Price = drive.Price,
                ImageUrl = drive.ImageUrl,
                Description = drive.Description,
                StockQuantity = drive.StockQuantity,
                WarrantyMonths = drive.WarrantyMonths,
                BrandId = drive.BrandId,

                // Специфични за Storage
                Type = drive.Type,
                Interface = drive.Interface,
                FormFactor = drive.FormFactor,
                CapacityGb = drive.CapacityGb,
                ReadSpeedMb = drive.ReadSpeedMb,
                WriteSpeedMb = drive.WriteSpeedMb,

                // Зареждаме марките за падащото меню
                Brands = await GetAllBrandsAsync()
            };
        }
        // 1. Помощен метод (Private)
        private void MapCaseData(Case computerCase, AddCaseViewModel model)
        {
            // Попълва общите неща (Име, Цена, Марка...)
            MapBaseProductInfo(computerCase, model);

            // Гаранцията
            computerCase.WarrantyMonths = model.WarrantyMonths;

            // Специфични за Case
            computerCase.FormFactor = model.FormFactor;
            computerCase.SupportedFormats = model.SupportedFormats;
            computerCase.HasMeshFront = model.HasMeshFront;
            computerCase.Color = model.Color;
            computerCase.LengthMm = model.LengthMm;
            computerCase.WidthMm = model.WidthMm;
            computerCase.HeightMm = model.HeightMm;
        }

        // 2. Създаване (CREATE) - Вече използва помощния метод
        public async Task CreateCaseAsync(AddCaseViewModel model)
        {
            var computerCase = new Case();

            // ЕДИН РЕД върши всичко!
            MapCaseData(computerCase, model);

            await this.dbContext.Cases.AddAsync(computerCase);
            await this.dbContext.SaveChangesAsync();
        }

        // 3. Редактиране (EDIT)
        public async Task EditCaseAsync(int id, AddCaseViewModel model)
        {
            var computerCase = await this.dbContext.Cases.FindAsync(id);
            if (computerCase == null) throw new ArgumentException("Invalid ID");

            // Използваме същия помощен метод
            MapCaseData(computerCase, model);

            await this.dbContext.SaveChangesAsync();
        }

        // 4. Взимане на данни за формата (GET)
        public async Task<AddCaseViewModel> GetCaseForEditAsync(int id)
        {
            var computerCase = await this.dbContext.Cases
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (computerCase == null) throw new ArgumentException("Invalid ID");

            return new AddCaseViewModel
            {
                // Общи данни
                Id = computerCase.Id,
                Name = computerCase.Name,
                Price = computerCase.Price,
                ImageUrl = computerCase.ImageUrl,
                Description = computerCase.Description,
                StockQuantity = computerCase.StockQuantity,
                WarrantyMonths = computerCase.WarrantyMonths,
                BrandId = computerCase.BrandId,

                // Специфични за Case
                FormFactor = computerCase.FormFactor,
                SupportedFormats = computerCase.SupportedFormats,
                HasMeshFront = computerCase.HasMeshFront,
                Color = computerCase.Color,
                LengthMm = computerCase.LengthMm,
                WidthMm = computerCase.WidthMm,
                HeightMm = computerCase.HeightMm,

                // Зареждаме марките за падащото меню
                Brands = await GetAllBrandsAsync()
            };
        }
        // 1. Помощен метод (Private)
        private void MapDisplayData(Display display, AddDisplayViewModel model)
        {
            // Попълва общите неща
            MapBaseProductInfo(display, model);

            // Гаранцията
            display.WarrantyMonths = model.WarrantyMonths;

            // Специфични за Display
            display.ScreenSizeInch = model.ScreenSizeInch;
            display.Resolution = model.Resolution;
            display.RefreshRateHz = model.RefreshRateHz;
            display.PanelType = model.PanelType;
            display.ResponseTimeMs = model.ResponseTimeMs;
            display.Ports = model.Ports;
            display.IsCurved = model.IsCurved;
        }

        // 2. Създаване (CREATE)
        public async Task CreateDisplayAsync(AddDisplayViewModel model)
        {
            var display = new Display();

            // Използваме помощния метод
            MapDisplayData(display, model);

            await this.dbContext.Displays.AddAsync(display);
            await this.dbContext.SaveChangesAsync();
        }

        // 3. Редактиране (EDIT)
        public async Task EditDisplayAsync(int id, AddDisplayViewModel model)
        {
            var display = await this.dbContext.Displays.FindAsync(id);
            if (display == null) throw new ArgumentException("Invalid ID");

            // Използваме същия помощен метод
            MapDisplayData(display, model);

            await this.dbContext.SaveChangesAsync();
        }

        // 4. Взимане на данни за формата (GET)
        public async Task<AddDisplayViewModel> GetDisplayForEditAsync(int id)
        {
            var display = await this.dbContext.Displays
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (display == null) throw new ArgumentException("Invalid ID");

            return new AddDisplayViewModel
            {
                // Общи данни
                Id = display.Id,
                Name = display.Name,
                Price = display.Price,
                ImageUrl = display.ImageUrl,
                Description = display.Description,
                StockQuantity = display.StockQuantity,
                WarrantyMonths = display.WarrantyMonths,
                BrandId = display.BrandId,

                // Специфични за Display
                ScreenSizeInch = display.ScreenSizeInch,
                Resolution = display.Resolution,
                RefreshRateHz = display.RefreshRateHz,
                PanelType = display.PanelType,
                ResponseTimeMs = display.ResponseTimeMs,
                Ports = display.Ports,
                IsCurved = display.IsCurved,

                // Зареждаме марките за падащото меню
                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapKeyboardData(Keyboard keyboard, AddKeyboardViewModel model)
        {
            // Общи
            MapBaseProductInfo(keyboard, model);
            keyboard.WarrantyMonths = model.WarrantyMonths;

            // Специфични
            keyboard.SwitchType = model.SwitchType;
            keyboard.Layout = model.Layout;
            keyboard.SizePercentage = model.SizePercentage;
            keyboard.ConnectionType = model.ConnectionType;
            keyboard.HasRgb = model.HasRgb;
        }

        // --- CREATE ---
        public async Task CreateKeyboardAsync(AddKeyboardViewModel model)
        {
            var keyboard = new Keyboard();
            MapKeyboardData(keyboard, model); // Използваме помощника

            await this.dbContext.Keyboards.AddAsync(keyboard);
            await this.dbContext.SaveChangesAsync();
        }

        // --- EDIT ---
        public async Task EditKeyboardAsync(int id, AddKeyboardViewModel model)
        {
            var keyboard = await this.dbContext.Keyboards.FindAsync(id);
            if (keyboard == null) throw new ArgumentException("Invalid ID");

            MapKeyboardData(keyboard, model); // Използваме помощника

            await this.dbContext.SaveChangesAsync();
        }

        // --- GET FOR EDIT ---
        public async Task<AddKeyboardViewModel> GetKeyboardForEditAsync(int id)
        {
            var kb = await this.dbContext.Keyboards
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (kb == null) throw new ArgumentException("Invalid ID");

            return new AddKeyboardViewModel
            {
                // Общи
                Id = kb.Id,
                Name = kb.Name,
                Price = kb.Price,
                ImageUrl = kb.ImageUrl,
                Description = kb.Description,
                StockQuantity = kb.StockQuantity,
                WarrantyMonths = kb.WarrantyMonths,
                BrandId = kb.BrandId,

                // Специфични
                SwitchType = kb.SwitchType,
                Layout = kb.Layout,
                SizePercentage = kb.SizePercentage,
                ConnectionType = kb.ConnectionType,
                HasRgb = kb.HasRgb,

                // Марки за падащото меню
                Brands = await GetAllBrandsAsync()
            };
        }
        private void MapMouseData(Mouse mouse, AddMouseViewModel model)
        {
            // Общи
            MapBaseProductInfo(mouse, model);
            mouse.WarrantyMonths = model.WarrantyMonths;

            // Специфични
            mouse.Dpi = model.Dpi;
            mouse.ConnectionType = model.ConnectionType;
            mouse.ButtonsCount = model.ButtonsCount;
            mouse.Color = model.Color;
            mouse.SensorType = model.SensorType;
            mouse.WeightGrams = model.WeightGrams;
        }

        // --- CREATE ---
        public async Task CreateMouseAsync(AddMouseViewModel model)
        {
            var mouse = new Mouse();
            MapMouseData(mouse, model); // Използваме помощника

            await this.dbContext.Mice.AddAsync(mouse); // Внимавай дали е Mice или Mouses в DbContext-а
            await this.dbContext.SaveChangesAsync();
        }

        // --- EDIT ---
        public async Task EditMouseAsync(int id, AddMouseViewModel model)
        {
            var mouse = await this.dbContext.Mice.FindAsync(id);
            if (mouse == null) throw new ArgumentException("Invalid ID");

            MapMouseData(mouse, model); // Използваме помощника

            await this.dbContext.SaveChangesAsync();
        }

        // --- GET FOR EDIT ---
        public async Task<AddMouseViewModel> GetMouseForEditAsync(int id)
        {
            var mouse = await this.dbContext.Mice
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (mouse == null) throw new ArgumentException("Invalid ID");

            return new AddMouseViewModel
            {
                // Общи
                Id = mouse.Id,
                Name = mouse.Name,
                Price = mouse.Price,
                ImageUrl = mouse.ImageUrl,
                Description = mouse.Description,
                StockQuantity = mouse.StockQuantity,
                WarrantyMonths = mouse.WarrantyMonths,
                BrandId = mouse.BrandId,

                // Специфични
                Dpi = mouse.Dpi,
                ConnectionType = mouse.ConnectionType,
                ButtonsCount = mouse.ButtonsCount,
                Color = mouse.Color,
                SensorType = mouse.SensorType,
                WeightGrams = mouse.WeightGrams,

                // Марки за падащото меню
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
