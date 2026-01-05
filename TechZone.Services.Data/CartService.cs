using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechZone.Services.Data.Interfaces;
using TechZoneProject.Data;
using TechZoneProject.Data.Models;
using TechZone.Web.ViewModels.Shop;

namespace TechZone.Services.Data
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext context;

        public CartService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddToCartAsync(string userId, int productId)
        {
            var cartItem = await context.CartItems
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (cartItem != null)
            {
                cartItem.Quantity++; 
            }
            else
            {
                cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                };
                await context.CartItems.AddAsync(cartItem);
            }

            await context.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            var item = await context.CartItems.FindAsync(cartItemId);
            if (item != null)
            {
                context.CartItems.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CartViewModel>> GetCartItemsAsync(string userId)
        {
            return await context.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product) 
                .Select(c => new CartViewModel
                {
                    Id = c.Id,
                    ProductId = c.ProductId,
                    ProductName = c.Product.Name,
                    ImageUrl = c.Product.ImageUrl,
                    Price = c.Product.Price,
                    Quantity = c.Quantity,
                    TotalPrice = c.Product.Price * c.Quantity
                })
                .ToListAsync();
        }
    }
}
