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
    
        // GET: Отваря формата за попълване
        [HttpGet]
        public async Task<IActionResult> AddCpu()
        {
            // 1. Създаваме модела и зареждаме марките вътре в него
            var model = new AddCpuViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCpu(AddCpuViewModel model)
        {
            // 1. Проверка за валидност (Required, Range и т.н.)
            if (!ModelState.IsValid)
            {
                // ВАЖНО: Ако има грешка, Brands ще е null, затова ги зареждаме пак!
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                // 2. Опит за запис
                await adminService.CreateCpuAsync(model);

                // 3. Успех -> Връщаме се в списъка с продукти в АДМИН зоната
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                // 4. Грешка -> Показваме съобщение на потребителя
                ModelState.AddModelError("", "Възникна неочаквана грешка при запис. Моля опитайте отново.");

                // Зареждаме марките пак, иначе падащото меню ще изчезне
                model.Brands = await adminService.GetAllBrandsAsync();

                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddGpu()
        {
            var model = new AddGpuViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddGpu(AddGpuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreateGpuAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddMotherboard()
        {
            var model = new AddMotherboardViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMotherboard(AddMotherboardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreateMotherboardAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddPowerSupply()
        {
            var model = new AddPowerSupplyViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPowerSupply(AddPowerSupplyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreatePowerSupplyAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddRam()
        {
            var model = new AddRamViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddRam(AddRamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreateRamAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddStorageDrive()
        {
            var model = new AddStorageDriveViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddStorageDrive(AddStorageDriveViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreateStorageDriveAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddCase()
        {
            var model = new AddCaseViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCase(AddCaseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreateCaseAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddDisplay()
        {
            var model = new AddDisplayViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDisplay(AddDisplayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreateDisplayAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddKeyboard()
        {
            var model = new AddKeyboardViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddKeyboard(AddKeyboardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreateKeyboardAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddMouse()
        {
            var model = new AddMouseViewModel
            {
                Brands = await adminService.GetAllBrandsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMouse(AddMouseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }

            try
            {
                await adminService.CreateMouseAsync(model);
                return RedirectToAction("SelectType", "Product", new { area = "Admin" });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Възникна грешка при добавянето на видео картата.");
                model.Brands = await adminService.GetAllBrandsAsync();
                return View(model);
            }
        }
    }
}
