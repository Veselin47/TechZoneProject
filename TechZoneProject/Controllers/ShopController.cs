using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Data.Interfaces;
using TechZone.Web.ViewModels.Shop; // <--- ВАЖНО: Добави това за новите модели

namespace TechZone.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService productService;

        public ShopController(IProductService productService)
        {
            this.productService = productService;
        }

        // 1. Страница с плочки "ХАРДУЕР"
        public IActionResult Index()
        {
            return View();
        }

        // 2. Страница с плочки "ПЕРИФЕРИЯ"
        public IActionResult Peripherals()
        {
            return View();
        }

        // 3. Списък с продукти + Филтри
        // URL пример: /Shop/Category/cpu?brand=Intel&minPrice=500
        [HttpGet]
        public async Task<IActionResult> Category(string id, [FromQuery] ProductSearchQueryModel query)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            // Викаме умния сървис с филтрите
            var viewModel = await this.productService.GetFilteredProductsAsync(id, query);

            // Слагаме хубаво заглавие на Български
            ViewData["CategoryName"] = GetCategoryTitle(id);
            ViewData["CategoryId"] = id; // Трябва ни за формата във View-то

            return View(viewModel);
        }

        // Помощен метод за превод на заглавията
        private string GetCategoryTitle(string categoryId)
        {
            return categoryId.ToLower() switch
            {
                "cpu" => "Процесори",
                "gpu" => "Видео Карти",
                "ram" => "RAM Памет",
                "motherboard" => "Дънни Платки",
                "ssd" => "SSD Дискове",
                "hdd" => "Твърди Дискове",
                "monitor" => "Монитори",
                "keyboard" => "Геймърски Клавиатури",
                "mouse" => "Геймърски Мишки",
                "headset" => "Слушалки",
                _ => "Продукти"
            };
        }
    }
}