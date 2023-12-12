using EMS_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
            : base(userManager, null, roleManager)
        {
        }
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList()); 
        }
        public IActionResult RoleCreate()
        {
            return View(); //add view
        }
        [HttpPost]
        public IActionResult RoleCreate()
    }
}
