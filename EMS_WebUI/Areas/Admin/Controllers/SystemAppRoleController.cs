using EMS_BLL.Services.Interfaces;
using EMS_DAL.Dtos;
using EMS_DAL.Enums;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemAppRoleController : Controller
    {
        private readonly IGenericService<SystemAppRoleDto, SystemAppRole> _service;
        private readonly IGenericService<PermissionDto, Permission> _permissionService;


        public SystemAppRoleController(IGenericService<SystemAppRoleDto, SystemAppRole> service, IGenericService<PermissionDto, Permission> permissionService)
        {
            _service = service;
            _permissionService = permissionService;
        }
        public async Task<ActionResult> Index()
        {
            var roleList = await _service.GetListAsync();

            foreach (var item in roleList)
            {
                var permission = await _permissionService.GetByIdAsync(item.PermissionId);
                item.PermissionDto = new PermissionDto()
                {
                    Id = permission.Id,
                    Title = permission.Title
                };
            }

            return View(roleList);
        }


        public async Task<IActionResult> Create()
        {

            SystemAppRoleDto model = new SystemAppRoleDto();
            ViewBag.PermissionDtos = await _permissionService.GetListAsync();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(SystemAppRoleDto itemDto)
        {
            var role = await _service.AddAsync(itemDto);
            if (role != null)
            {
                TempData["success"] = "Role has been successfully added.";
                return RedirectToAction("Index");
            }
            return Ok(role);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            ViewBag.PermissionDtos = await _permissionService.GetListAsync();
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(SystemAppRoleDto itemDto)
        {
            var model = _service.Update(itemDto);

            if (model != null)
            {
                TempData["success"] = "Role has been successfully updated.";
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            ViewBag.PermissionDtos = await _permissionService.GetListAsync();
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(SystemAppRoleDto itemDto)
        {
            _service.Delete(itemDto.Id);
            TempData["success"] = "Role has been successfully deleted.";
            return RedirectToAction("Index");


        }


    }
}
