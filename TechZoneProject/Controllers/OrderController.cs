using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Contracts;
using TechZone.Web.ViewModels.Order;
using TechZoneProject.Data.Models;

namespace TechZone.Web.Controllers
{
    [Authorize] 
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = userManager.GetUserId(User);

            var model = await orderService.GetCheckoutDataAsync(userId);

            if (!model.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var userId = userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                try
                {
                    bool result = await orderService.CreateOrderAsync(userId, model);
                    if (result)
                    {
                        return RedirectToAction("Success");
                    }
                }
                catch (Exception ex)
                {
                    
                    ModelState.AddModelError("", "Възникна грешка: " + ex.Message);
                }
            }

            var cartData = await orderService.GetCheckoutDataAsync(userId);
            model.Items = cartData.Items;
            model.TotalAmount = cartData.TotalAmount;

            return View(model);
        }

        
        public IActionResult Success()
        {
            return View();
        }
    }
}