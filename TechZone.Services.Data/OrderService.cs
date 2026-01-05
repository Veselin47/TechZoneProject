using Microsoft.EntityFrameworkCore;
using TechZone.Services.Contracts;
using TechZone.Web.ViewModels.Order;
using TechZone.Web.ViewModels.Shop;
using TechZoneProject.Data;
using TechZoneProject.Data.Models;

namespace TechZone.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CheckoutViewModel> GetCheckoutDataAsync(string userId)
        {
            var cartItems = await context.CartItems
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

            return new CheckoutViewModel
            {
                Items = cartItems,
                TotalAmount = cartItems.Sum(x => x.TotalPrice)
            };
        }

        public async Task<bool> CreateOrderAsync(string userId, CheckoutViewModel model)
        {
           
            var cartItems = await context.CartItems
                .Where(c => c.UserId == userId)
                .Include(c => c.Product)
                .ToListAsync();

            if (!cartItems.Any()) return false;

            
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                TotalAmount = cartItems.Sum(c => c.Quantity * c.Product.Price),
                CreatedOn = DateTime.UtcNow,

                
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ShippingAddress = model.Address, 
                City = model.City,
                PostalCode = model.PostalCode,
                OrderNote = model.OrderNote
            };

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem
                {
                    Order = order,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    PriceAtPurchase = item.Product.Price
                };

                if (item.Product.StockQuantity >= item.Quantity)
                {
                    item.Product.StockQuantity -= item.Quantity;
                }
                else
                {
                    throw new InvalidOperationException($"Not enough stock for {item.Product.Name}");
                }

                await context.OrderItems.AddAsync(orderItem);
            }

            await context.Orders.AddAsync(order);

           
            context.CartItems.RemoveRange(cartItems);

            await context.SaveChangesAsync();
            return true;
        }
    }
}