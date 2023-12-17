using Microsoft.AspNetCore.Mvc;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    public class SystemAppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
