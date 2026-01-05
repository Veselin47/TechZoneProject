using Microsoft.EntityFrameworkCore;
using TechZone.Services.Data.Interfaces;
using TechZone.Web.ViewModels.Home;
using TechZone.Web.ViewModels.Shop;
using TechZoneProject.Data;
using TechZoneProject.Data.Models;

namespace TechZone.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;

        
        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductIndexViewModel>> GetLastProductsAsync(int count)
        {
            return await this.dbContext
                .Products
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.Id)
                .Take(count)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Brand = p.Brand.Name,
                    IsAvailable = p.StockQuantity > 0
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<ProductIndexViewModel>> GetProductsByCategoryAsync(string categoryName)
        {
            IQueryable<Product> query = this.dbContext.Products;

            switch (categoryName.ToLower())
            {
                case "cpu":
                    query = this.dbContext.Cpus;
                    break;
                case "gpu":
                    query = this.dbContext.Gpus;
                    break;
                case "ram":
                    query = this.dbContext.Rams;
                    break;
                case "display":
                case "monitor":
                    query = this.dbContext.Displays;
                    break;
                case "keyboard":
                    query = this.dbContext.Keyboards;
                    break;
                case "mouse":
                    query = this.dbContext.Mice;     
                    break;
                case "case":
                    query = this.dbContext.Cases;
                    break;
                default:
                    return new List<ProductIndexViewModel>();
            }

            return await query
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Brand = p.Brand.Name,
                    IsAvailable = p.StockQuantity > 0
                })
                .ToListAsync();
        }
        public async Task<AllProductsViewModel> GetFilteredProductsAsync(string category, ProductSearchQueryModel query)
        {
           
            IQueryable<Product> productsQuery = this.dbContext.Products;

         
            switch (category.ToLower())
            {
                case "cpu": productsQuery = this.dbContext.Cpus; break;
                case "gpu": productsQuery = this.dbContext.Gpus; break;
                case "ram": productsQuery = this.dbContext.Rams; break;
                case "motherboard": productsQuery = this.dbContext.Motherboards; break;
                case "monitor": productsQuery = this.dbContext.Displays; break;
                case "keyboard": productsQuery = this.dbContext.Keyboards; break;
                case "mouse": productsQuery = this.dbContext.Mice; break;
                case "case": productsQuery = this.dbContext.Cases; break;
                case "ssd":    
                case "hdd":
                case "storage": productsQuery = this.dbContext.StorageDrives; break;
                case "psu": productsQuery = this.dbContext.PowerSupplies; break;
 
                default: break;
            }

            if (!string.IsNullOrEmpty(query.Brand))
            {
                productsQuery = productsQuery.Where(p => p.Brand.Name == query.Brand);
            }

            if (!string.IsNullOrEmpty(query.SearchTerm))
            {
                string wildCard = $"%{query.SearchTerm.ToLower()}%";
                productsQuery = productsQuery.Where(p => EF.Functions.Like(p.Name.ToLower(), wildCard));
            }

            if (query.MinPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price >= query.MinPrice.Value);
            }
            if (query.MaxPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price <= query.MaxPrice.Value);
            }
            
            if (category.ToLower() == "storage" && !string.IsNullOrEmpty(query.StorageType))
            {
                

                productsQuery = productsQuery
                    .OfType<StorageDrive>()
                    .Where(s => s.Type == query.StorageType);
            }
            
            productsQuery = query.Sorting switch
            {
                0 => productsQuery.OrderBy(p => p.Price), 
                1 => productsQuery.OrderByDescending(p => p.Price), 
                2 => productsQuery.OrderByDescending(p => p.Id), 
                _ => productsQuery.OrderBy(p => p.Id)
            };

          
            var products = await productsQuery
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Brand = p.Brand.Name,
                    IsAvailable = p.StockQuantity > 0
                })
                .ToListAsync();

            
           

            IQueryable<Product> brandsQuery = this.dbContext.Products; 

            switch (category.ToLower())
            {
                case "cpu":
                    brandsQuery = this.dbContext.Cpus;
                    break;
                case "gpu":
                    brandsQuery = this.dbContext.Gpus;
                    break;
                case "ram":
                    brandsQuery = this.dbContext.Rams;
                    break;
                case "motherboard":
                    brandsQuery = this.dbContext.Motherboards;
                    break;
                case "storage":
                case "ssd":
                case "hdd":
                    brandsQuery = this.dbContext.StorageDrives;
                    break;
                case "case":
                     brandsQuery = this.dbContext.Cases; 
                    break;
                case "psu":
                     brandsQuery = this.dbContext.PowerSupplies; 
                    break;
                case "monitor":
                case "display":
                    brandsQuery = this.dbContext.Displays;
                    break;
                case "keyboard":
                    brandsQuery = this.dbContext.Keyboards;
                    break;
                case "mouse":
                    brandsQuery = this.dbContext.Mice;
                    break;
              
            }

            var brands = await brandsQuery
                .Where(p => !p.IsDeleted)
                .Select(p => p.Brand.Name)
                .Distinct() 
                .OrderBy(b => b) 
                .ToListAsync();

         
            return new AllProductsViewModel
            {
                CategoryName = category,
                Products = products,
                Brands = brands,
                SearchQuery = query 
            };
        }
        public async Task<ProductDetailsViewModel> GetProductDetailsAsync(int id)
        {
          
            var product = await dbContext.Products
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null) return null;

           
            var model = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                IsAvailable = product.StockQuantity > 0,
                Brand = product.Brand.Name,
                Category = product.GetType().Name 
            };

      
            FillSpecifications(product, model);

            return model;
        }
        private void FillSpecifications(Product product, ProductDetailsViewModel model)
        {
            
            var specs = product switch
            {
                Cpu cpu => new Dictionary<string, string>
                {
                    ["Сокет"] = cpu.Socket,
                    ["Ядра (Physical)"] = cpu.PhysicalCores.ToString(),
                    ["Нишки (Logical)"] = cpu.LogicalCores.ToString(),
                    ["Честота"] = $"{cpu.BaseFrequencyGhz} GHz",
                    ["Turbo Boost"] = $"{cpu.TurboFrequencyGhz} GHz",
                    ["Кеш"] = cpu.Cache,
                    ["Охладител"] = cpu.HasBoxCooler ? "Да" : "Не"
                },

                Gpu gpu => new Dictionary<string, string>
                {
                    ["Памет"] = $"{gpu.MemorySizeGb} GB",
                    ["Тип памет"] = gpu.MemoryType,
                    ["Шина"] = $"{gpu.BusWidthBit} bit",
                    ["Честота"] = $"{gpu.FrequencyMhz} MHz"
                },

                Ram ram => new Dictionary<string, string>
                {
                    ["Капацитет"] = $"{ram.CapacityGb} GB",
                    ["Тип"] = ram.Type,
                    ["Скорост"] = $"{ram.SpeedMt} MT/s",
                    ["Тайминг"] = ram.Timing,
                    ["RGB"] = ram.HasRgb ? "Да" : "Не",
                    ["Kit"] = ram.IsKit ? "Да (2x)" : "Не (1x)"
                },

                Motherboard mb => new Dictionary<string, string>
                {
                    ["Сокет"] = mb.Socket,
                    ["Чипсет"] = mb.Chipset,
                    ["Форм-фактор"] = mb.FormFactor,
                    ["Слотове за памет"] = mb.MemorySlots.ToString(),
                    ["Wi-Fi"] = mb.HasWifi ? "Да" : "Не"
                },

                StorageDrive drive => new Dictionary<string, string>
                {
                    ["Тип"] = drive.Type,
                    ["Капацитет"] = $"{drive.CapacityGb} GB",
                    ["Интерфейс"] = drive.Interface,
                    ["Четене"] = $"{drive.ReadSpeedMb} MB/s",
                    ["Писане"] = $"{drive.WriteSpeedMb} MB/s"
                },

                Display display => new Dictionary<string, string>
                {
                    ["Размер"] = $"{display.ScreenSizeInch} инча",
                    ["Резолюция"] = display.Resolution,
                    ["Опресняване"] = $"{display.RefreshRateHz} Hz",
                    ["Панел"] = display.PanelType,
                    ["Време за реакция"] = $"{display.ResponseTimeMs} ms"
                },

                Case pcCase => new Dictionary<string, string>
                {
                    ["Форм-фактор"] = pcCase.FormFactor,
                    ["Цвят"] = pcCase.Color,
                    ["Mesh преден панел"] = pcCase.HasMeshFront ? "Да" : "Не",
                    ["Размери"] = $"{pcCase.LengthMm}x{pcCase.WidthMm}x{pcCase.HeightMm} mm"
                },

                PowerSupply psu => new Dictionary<string, string>
                {
                    ["Мощност"] = $"{psu.PowerWatts} W",
                    ["Сертификат"] = psu.Certification,
                    ["Модулно"] = psu.IsModular ? "Да" : "Не"
                },

                Keyboard kb => new Dictionary<string, string>
                {
                    ["Тип суичове"] = kb.SwitchType,
                    ["Подредба (Layout)"] = kb.Layout,
                    ["Размер"] = $"{kb.SizePercentage}%",
                    ["Свързване"] = kb.ConnectionType,
                    ["RGB осветление"] = kb.HasRgb ? "Да" : "Не"
                },

                Mouse mouse => new Dictionary<string, string>
                {
                    ["DPI (Чувствителност)"] = mouse.Dpi.ToString(),
                    ["Сензор"] = mouse.SensorType,
                    ["Брой бутони"] = mouse.ButtonsCount.ToString(),
                    ["Свързване"] = mouse.ConnectionType,
                    ["Тегло"] = $"{mouse.WeightGrams} гр.",
                    ["Цвят"] = mouse.Color
                },


               
                _ => new Dictionary<string, string>()
            };

           
            foreach (var kvp in specs)
            {
                model.Specifications.Add(kvp.Key, kvp.Value);
            }
        }
    }
}