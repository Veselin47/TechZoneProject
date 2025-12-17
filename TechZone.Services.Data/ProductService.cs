using Microsoft.EntityFrameworkCore;
using TechZone.Services.Data.Interfaces;
using TechZone.Web.ViewModels.Home;
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
    }
}