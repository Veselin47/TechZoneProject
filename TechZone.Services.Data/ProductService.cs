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

        // Взимаме базата чрез Constructor Injection
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

            // Тук използваме силата на EF Core - филтрираме по тип
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
                    query = this.dbContext.Keyboards; // Ако ти дава грешка, значи не си ги добавил в DbContext
                    break;
                case "mouse":
                    query = this.dbContext.Mice;      // Внимание: Множественото число на Mouse е Mice в EF Core 
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
            // 1. Взимаме всички продукти като Базова заявка
            IQueryable<Product> productsQuery = this.dbContext.Products;

            // 2. Филтрираме по КАТЕГОРИЯ
            switch (category.ToLower())
            {
                case "cpu": productsQuery = this.dbContext.Cpus; break;
                case "gpu": productsQuery = this.dbContext.Gpus; break;
                case "ram": productsQuery = this.dbContext.Rams; break;
                case "motherboard": productsQuery = this.dbContext.Motherboards; break;
                case "monitor": productsQuery = this.dbContext.Displays; break;
                case "keyboard": productsQuery = this.dbContext.Keyboards; break;
                case "mouse": productsQuery = this.dbContext.Mice; break;
                default: break; // Ако е грешна категория, връща празен списък по-долу
            }

            // 3. Филтрираме по МАРКА (Ако потребителят е избрал такава)
            if (!string.IsNullOrEmpty(query.Brand))
            {
                productsQuery = productsQuery.Where(p => p.Brand.Name == query.Brand);
            }

            // 4. Филтрираме по ТЪРСЕНЕ (Текст)
            if (!string.IsNullOrEmpty(query.SearchTerm))
            {
                string wildCard = $"%{query.SearchTerm.ToLower()}%";
                productsQuery = productsQuery.Where(p => EF.Functions.Like(p.Name.ToLower(), wildCard));
            }

            // 5. Филтрираме по ЦЕНА
            if (query.MinPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price >= query.MinPrice.Value);
            }
            if (query.MaxPrice.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price <= query.MaxPrice.Value);
            }

            // 6. СОРТИРАНЕ
            productsQuery = query.Sorting switch
            {
                0 => productsQuery.OrderBy(p => p.Price), // Най-ниска цена
                1 => productsQuery.OrderByDescending(p => p.Price), // Най-висока
                2 => productsQuery.OrderByDescending(p => p.Id), // Най-нови
                _ => productsQuery.OrderBy(p => p.Id)
            };

            // 7. Взимаме резултатите и ги превръщаме във ViewModels
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

            // 8. Взимаме СПИСЪК С МАРКИ (за да напълним филтъра)
            // Важно: Правим го върху първоначалната категория, не върху филтрираните, 
            // за да може потребителят да види всички възможни марки.
            var brandsQuery = this.dbContext.Products.AsQueryable();

            // (Повтаряме суича набързо само за марките - може да се оптимизира, но за сега така е ясно)
            switch (category.ToLower())
            {
                case "cpu": brandsQuery = this.dbContext.Cpus; break;
                case "gpu": brandsQuery = this.dbContext.Gpus; break;
                case "ram": brandsQuery = this.dbContext.Rams; break;
                    // ... добави и другите ...
            }

            var brands = await brandsQuery
                .Where(p => !p.IsDeleted)
                .Select(p => p.Brand.Name)
                .Distinct()
                .ToListAsync();

            // 9. Сглобяваме всичко
            return new AllProductsViewModel
            {
                CategoryName = category,
                Products = products,
                Brands = brands,
                SearchQuery = query // Връщаме избора на потребителя обратно
            };
        }
    }
}