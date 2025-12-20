using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechZoneProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")] // Казваме, че това е част от Admin зоната
    [Authorize(Roles = "Administrator")] // САМО ЗА АДМИНИСТРАТОРИ!
    public class BaseAdminController : Controller
    {

    }
}