using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitsTraceabilitySystem.Web.Areas.Admin.Controllers
{
    public class AdministratorController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {   
            return View();
        }
    }
}
