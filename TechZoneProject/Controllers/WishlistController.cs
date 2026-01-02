using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Data.Interfaces;
using TechZoneProject.Data.Models;

namespace TechZoneProject.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly IWishlistService wishlistService;
        private readonly UserManager<ApplicationUser> userManager;

        public WishlistController(IWishlistService wishlistService, UserManager<ApplicationUser> userManager)
        {
            this.wishlistService = wishlistService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);
            var products = await wishlistService.GetUserWishlistAsync(userId);
            return View(products);
        }

        public async Task<IActionResult> Add(int productId, string returnUrl)
        {
            var userId = userManager.GetUserId(User);
            await wishlistService.AddToWishlistAsync(userId, productId);

            if (!string.IsNullOrEmpty(returnUrl)) return Redirect(returnUrl);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int productId)
        {
            var userId = userManager.GetUserId(User);
            await wishlistService.RemoveFromWishlistAsync(userId, productId);
            return RedirectToAction("Index");
        }
    }
}
