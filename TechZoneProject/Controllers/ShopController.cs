using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Data.Interfaces;

namespace TechZone.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService productService;

        public ShopController(IProductService productService)
        {
            this.productService = productService;
        }

        // 1. Страницата с плочките (Категориите)
        // URL: /Shop
        public IActionResult Index()
        {
            return View(); // Това View ще е статично с картинки на категориите
        }

        // 2. Списъкът с продукти
        // URL: /Shop/Category/cpu
        public async Task<IActionResult> Category(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var products = await this.productService.GetProductsByCategoryAsync(id);

            // Използваме ViewData, за да покажем заглавие "Процесори" вместо generic текст
            ViewData["CategoryName"] = id.ToUpper();

            return View(products);
        }
    }
}