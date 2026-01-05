using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechZoneProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")] 
    [Authorize(Roles = "Administrator")] 
    public class BaseAdminController : Controller
    {

    }
}