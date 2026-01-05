using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Contracts;
using TechZone.Services.Data.Interfaces.TechZone.Services.Contracts;

namespace TechZone.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class OrderController : Controller
    {
        private readonly IAdminOrderService orderService;

        public OrderController(IAdminOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await orderService.GetAllOrdersAsync();
            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await orderService.GetOrderDetailsAsync(id);
            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            await orderService.UpdateOrderStatusAsync(id, status);
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}