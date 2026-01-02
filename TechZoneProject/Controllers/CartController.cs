using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Data.Interfaces;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Controllers
{
    [Authorize] 
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);
            var items = await cartService.GetCartItemsAsync(userId);
            return View(items);
        }

        public async Task<IActionResult> Add(int productId, string returnUrl)
        {
            var userId = userManager.GetUserId(User);
            await cartService.AddToCartAsync(userId, productId);

            // Връщаме потребителя там, откъдето е дошъл (каталога)
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await cartService.RemoveFromCartAsync(id);
            return RedirectToAction("Index");
        }
    }
}
