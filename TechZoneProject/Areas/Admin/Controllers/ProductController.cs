using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Data.Interfaces;
using TechZone.Web.ViewModels.Admin.Models;

namespace TechZoneProject.Areas.Admin.Controllers
{
    // 1. Казваме, че този контролер е част от Админ зоната
    [Area("Admin")]
    // 2. Само Админи могат да го ползват
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly IAdminProductService adminService;

        // 3. Инжектираме сървиса, който създадохме преди малко
        public ProductController(IAdminProductService adminService)
        {
            this.adminService = adminService;
        }
        [HttpGet]
        public IActionResult SelectType()
        {
            return View();
        }
        // ==========================================
        // МЕТОДИ ЗА CPU (ПРОЦЕСОР)
        // ==========================================

        // GET: Отваря формата за попълване
        [HttpGet]
        public async Task<IActionResult> AddCpu()
        {
            try
            {
                // Зареждаме марките (Intel, AMD) за падащото меню
                ViewBag.Brands = await this.adminService.GetAllBrandsAsync();

                return View();
            }
            catch (Exception ex)
            {
                // Ако нещо гръмме още при зареждането
                return Content("Грешка при зареждане: " + ex.Message);
            }
        }

        // POST: Приема данните от бутона "Запиши"
        [HttpPost]
        public async Task<IActionResult> AddCpu(AddCpuViewModel model)
        {
            // Проверка дали формата е попълнена правилно (валидациите)
            if (!ModelState.IsValid)
            {
                // Ако има грешка, презареждаме марките и връщаме формата с грешките
                ViewBag.Brands = await this.adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                // Извикваме логиката за запис в базата
                await this.adminService.CreateCpuAsync(model);

                // УСПЕХ! Връщаме се на началното табло
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                // ГРЕШКА ПРИ ЗАПИС
                ModelState.AddModelError("", "Възникна неочаквана грешка: " + ex.Message);

                // Връщаме потребителя обратно във формата, за да не си загуби данните
                ViewBag.Brands = await this.adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
    }
}
