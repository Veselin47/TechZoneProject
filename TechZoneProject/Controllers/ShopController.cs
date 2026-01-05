using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Data.Interfaces;
using TechZone.Web.ViewModels.Shop; 

namespace TechZone.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService productService;

        public ShopController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Peripherals()
        {
            return View();
        }

    
        [HttpGet]
        public async Task<IActionResult> Category(string id, [FromQuery] ProductSearchQueryModel query)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            
            var viewModel = await this.productService.GetFilteredProductsAsync(id, query);

           
            ViewData["CategoryName"] = GetCategoryTitle(id);
            ViewData["CategoryId"] = id; 

            return View(viewModel);
        }

        private string GetCategoryTitle(string categoryId)
        {
            return categoryId.ToLower() switch
            {
                "cpu" => "Процесори",
                "gpu" => "Видео Карти",
                "ram" => "RAM Памет",
                "motherboard" => "Дънни Платки",
                "storage" => "Дискове и Памет",
                "monitor" => "Монитори",
                "keyboard" => "Геймърски Клавиатури",
                "mouse" => "Геймърски Мишки",
                "headset" => "Слушалки",
                _ => "Продукти"
            };
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await productService.GetProductDetailsAsync(id);

            if (model == null)
            {
                return NotFound(); 
            }

            return View(model);
        }
    }
}