using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechZone.Services.Data.Interfaces;
using TechZone.Web.ViewModels.Admin.Models;

namespace TechZoneProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly IAdminProductService adminService;

        
        public ProductController(IAdminProductService adminService)
        {
            this.adminService = adminService;
        }
        [HttpGet]
        public IActionResult SelectType()
        {
            return View();
        }

        // !!! Методи за добавяне на продукти от различни типове !!!

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

        // !!! Край на методите за добавяне на продукти от различни типове !!!

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await this.adminService.GetAllProductsAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this.adminService.DeleteProductAsync(id);
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(All)); 
        }


        //===========EDIT=============

        [HttpGet]
        public async Task<IActionResult> EditCpu(int id)
        {
            try
            {
                var model = await this.adminService.GetCpuForEditAsync(id);

                // Слагаме флаг, за да може View-то да знае, че редактираме
                ViewData["IsEdit"] = true;

                // ВРЪЩАМЕ СЪЩОТО VIEW КАТО ЗА ДОБАВЯНЕ!
                return View("AddCpu", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCpu(int id, AddCpuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddCpu", model);
            }

            try
            {
                await this.adminService.EditCpuAsync(id, model);
                return RedirectToAction(nameof(All)); // Обратно в таблицата
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при редакция.");
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddCpu", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditGpu(int id)
        {
            try
            {
                var model = await this.adminService.GetGpuForEditAsync(id);

                // Слагаме флаг, за да може View-то да знае, че редактираме
                ViewData["IsEdit"] = true;

                // ВРЪЩАМЕ СЪЩОТО VIEW КАТО ЗА ДОБАВЯНЕ!
                return View("AddGpu", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditGpu(int id, AddGpuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddGpu", model);
            }

            try
            {
                await this.adminService.EditGpuAsync(id, model);
                return RedirectToAction(nameof(All)); // Обратно в таблицата
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при редакция.");
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddGpu", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditMotherboard(int id)
        {
            try
            {
                var model = await this.adminService.GetMotherboardForEditAsync(id);

                // Слагаме флаг, за да може View-то да знае, че редактираме
                ViewData["IsEdit"] = true;

                // ВРЪЩАМЕ СЪЩОТО VIEW КАТО ЗА ДОБАВЯНЕ!
                return View("AddMotherboard", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditMotherboard(int id, AddMotherboardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddMotherboard", model);
            }

            try
            {
                await this.adminService.EditMotherboardAsync(id, model);
                return RedirectToAction(nameof(All)); // Обратно в таблицата
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при редакция.");
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddMotherboard", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditRam(int id)
        {
            try
            {
                var model = await this.adminService.GetRamForEditAsync(id);

                // Слагаме флаг, за да може View-то да знае, че редактираме
                ViewData["IsEdit"] = true;

                // ВРЪЩАМЕ СЪЩОТО VIEW КАТО ЗА ДОБАВЯНЕ!
                return View("AddRam", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditRam(int id, AddRamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddRam", model);
            }

            try
            {
                await this.adminService.EditRamAsync(id, model);
                return RedirectToAction(nameof(All)); 
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при редакция.");
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddRam", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditPowerSupply(int id)
        {
            try
            {
                var model = await this.adminService.GetPowerSupplyForEditAsync(id);

                // Слагаме флаг, за да може View-то да знае, че редактираме
                ViewData["IsEdit"] = true;

                // ВРЪЩАМЕ СЪЩОТО VIEW КАТО ЗА ДОБАВЯНЕ!
                return View("AddPowerSupply", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditPowerSupply(int id, AddPowerSupplyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddPowerSupply", model);
            }

            try
            {
                await this.adminService.EditPowerSupplyAsync(id, model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при редакция.");
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddPowerSupply", model);
            }
        }
        

        [HttpGet]
        public async Task<IActionResult> EditStorageDrive(int id)
        {
            try
            {
                var model = await this.adminService.GetStorageDriveForEditAsync(id);

                // Слагаме флаг, за да може View-то да знае, че редактираме
                ViewData["IsEdit"] = true;

                // ВРЪЩАМЕ СЪЩОТО VIEW КАТО ЗА ДОБАВЯНЕ!
                return View("AddStorageDrive", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditStorageDrive(int id, AddStorageDriveViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddStorageDrive", model);
            }

            try
            {
                await this.adminService.EditStorageDriveAsync(id, model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при редакция.");
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddStorageDrive", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditCase(int id)
        {
            try
            {
                var model = await this.adminService.GetCaseForEditAsync(id);

                // Слагаме флаг, за да може View-то да знае, че редактираме
                ViewData["IsEdit"] = true;

                // ВРЪЩАМЕ СЪЩОТО VIEW КАТО ЗА ДОБАВЯНЕ!
                return View("AddCase", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCase(int id, AddCaseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddCase", model);
            }

            try
            {
                await this.adminService.EditCaseAsync(id, model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при редакция.");
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddCase", model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditDisplay(int id)
        {
            try
            {
                var model = await this.adminService.GetDisplayForEditAsync(id);

                // Слагаме флаг, за да може View-то да знае, че редактираме
                ViewData["IsEdit"] = true;

                // ВРЪЩАМЕ СЪЩОТО VIEW КАТО ЗА ДОБАВЯНЕ!
                return View("AddDisplay", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditDisplay(int id, AddDisplayViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddDisplay", model);
            }

            try
            {
                await this.adminService.EditDisplayAsync(id, model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при редакция.");
                model.Brands = await this.adminService.GetAllBrandsAsync();
                ViewData["IsEdit"] = true;
                return View("AddDisplay", model);
            }
        }
    }
}
