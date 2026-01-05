using Microsoft.EntityFrameworkCore;
using TechZone.Services.Contracts;
using TechZone.Services.Data.Interfaces.TechZone.Services.Contracts;
using TechZone.Web.ViewModels.Admin.Models;
using TechZoneProject.Data;

namespace TechZone.Services.Data
{
    public class AdminOrderService : IAdminOrderService
    {
        private readonly ApplicationDbContext context;

        public AdminOrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<OrderAdminViewModel>> GetAllOrdersAsync()
        {
            return await context.Orders
                .OrderByDescending(o => o.OrderDate) 
                .Select(o => new OrderAdminViewModel
                {
                    Id = o.Id,
                    UserEmail = o.User.Email,
                    OrderDate = o.OrderDate,
                    Status = o.Status,
                    TotalAmount = o.TotalAmount,
                    ItemsCount = o.OrderItems.Sum(i => i.Quantity)
                })
                .ToListAsync();
        }

        public async Task<OrderDetailsAdminViewModel> GetOrderDetailsAsync(int id)
        {
            var order = await context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return new OrderDetailsAdminViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                CustomerName = $"{order.FirstName} {order.LastName}",
                Phone = order.PhoneNumber,
                Email = order.User.Email,
                ShippingAddress = order.ShippingAddress,
                City = order.City,
                PostalCode = order.PostalCode,
                Note = order.OrderNote,
                TotalAmount = order.TotalAmount,
                Items = order.OrderItems.Select(i => new OrderItemViewModel
                {
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    Price = i.PriceAtPurchase
                })
            };
        }

        public async Task UpdateOrderStatusAsync(int id, string newStatus)
        {
            var order = await context.Orders.FindAsync(id);
            if (order != null)
            {
                order.Status = newStatus;
                await context.SaveChangesAsync();
            }
        }
    }
}