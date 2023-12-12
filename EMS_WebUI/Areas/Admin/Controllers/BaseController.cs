using EMS_DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<AppUser> _userManager { get; }
        protected SignInManager<AppUser> _signInManager { get; }
        public RoleManager<AppRole> _roleManager { get; set; }

        protected AppUser CurrentUser => _userManager.FindByNameAsync(User.Identity.Name).Result;
        protected BaseController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public void AddModelError(IdentityResult result)
        { 
        foreach(var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
    }
}
