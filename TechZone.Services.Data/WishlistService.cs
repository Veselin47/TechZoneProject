using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechZone.Services.Data.Interfaces;
using TechZone.Web.ViewModels.Admin.Models;
using TechZoneProject.Data;
using TechZoneProject.Data.Models;

namespace TechZone.Services.Data
{
    public class WishlistService : IWishlistService
    {
        private readonly ApplicationDbContext context;

        public WishlistService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddToWishlistAsync(string userId, int productId)
        {
          
            bool exists = await context.WishlistItems
                .AnyAsync(w => w.UserId == userId && w.ProductId == productId);

            if (!exists)
            {
                await context.WishlistItems.AddAsync(new WishlistItem
                {
                    UserId = userId,
                    ProductId = productId
                });
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromWishlistAsync(string userId, int productId)
        {
            var item = await context.WishlistItems
                .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);

            if (item != null)
            {
                context.WishlistItems.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductAllViewModel>> GetUserWishlistAsync(string userId)
        {
            return await context.WishlistItems
                .Where(w => w.UserId == userId)
                .Include(w => w.Product)
                .ThenInclude(p => p.Brand)
                .Select(w => new ProductAllViewModel 
                {
                    Id = w.Product.Id,
                    Name = w.Product.Name,
                    ImageUrl = w.Product.ImageUrl,
                    Price = w.Product.Price,
                    Brand = w.Product.Brand.Name,
                    IsAvailable = w.Product.StockQuantity > 0
                })
                .ToListAsync();
        }
    }
}
