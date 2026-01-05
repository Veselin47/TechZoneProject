using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechZoneProject.Models;
using TechZone.Services.Data.Interfaces;


namespace TechZone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await this.productService.GetLastProductsAsync(6);

            return View(viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contacts()
        {
            return View();
        }
    }
}
