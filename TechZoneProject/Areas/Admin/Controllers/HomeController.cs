using Microsoft.AspNetCore.Mvc;
using TechZoneProject.Web.Areas.Admin.Controllers;

namespace TechZoneProject.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
