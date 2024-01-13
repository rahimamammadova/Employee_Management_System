using EMS_BLL.Services.Interfaces;
using EMS_DAL.DBModels;
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
        private readonly IGenericService<SystemAppRolePermissionDto, SystemAppRolePermission> _rolePermissionService;

        public SystemAppRoleController(IGenericService<SystemAppRoleDto, SystemAppRole> service, IGenericService<PermissionDto, Permission> permissionService, IGenericService<SystemAppRolePermissionDto, SystemAppRolePermission> rolePermissionService)
        {
            _service = service;
            _permissionService = permissionService;
            _rolePermissionService = rolePermissionService;
        }
        public async Task<ActionResult> Index()
        {
            var roleList = await _service.GetListAsync();
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


        public async Task<IActionResult> ShowPermission(Guid id)
        {
            List<SystemAppRolePermissionDto> rolePermissionDtoList = new List<SystemAppRolePermissionDto>();
            var rolePermisions = await _rolePermissionService.GetListAsync();
            var rolePermissionList = rolePermisions.Where(x => x.RoleId == id).ToList();

            TempData["RoleId"] = id;
            foreach (var rolePermission in rolePermissionList)
            {
                var permission = await _permissionService.GetByIdAsync(rolePermission.PermissionId);
                rolePermission.PermissionTitle = permission.Title;
                rolePermissionDtoList.Add(rolePermission);
            }
            return View(rolePermissionDtoList);

        }


        public async Task<IActionResult> AssignPermission()
        {
            Guid roleId = Guid.Empty;
            if (TempData.ContainsKey("RoleId"))
            {
                roleId = Guid.Parse(TempData["RoleId"].ToString());
            }

            SystemAppRolePermissionDto model = new SystemAppRolePermissionDto();

            var role = await _service.GetByIdAsync(roleId);
            model.RoleTitle = role.Title;
            model.RoleId = role.Id;

            ViewBag.PermissionDtos = await _permissionService.GetListAsync();

            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> AssignPermission(SystemAppRolePermissionDto itemDto)
        {
            var model = _rolePermissionService.AddAsync(itemDto);

            if (model != null)
            {
                TempData["success"] = "Role Permission has been successfully updated.";
                return RedirectToAction("Index");
            }
            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> DeletePermission(Guid id)
        {
            _rolePermissionService.Delete(id);
            TempData["success"] = "Role Permission has been successfully deleted.";
            return RedirectToAction("Index");

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
