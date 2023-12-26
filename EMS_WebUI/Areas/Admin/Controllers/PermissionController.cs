using EMS_BLL.Services.Interfaces;
using EMS_DAL.Dtos;
using EMS_DAL.Enums;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PermissionController : Controller
    {
        private readonly IGenericService<PermissionDto, Permission> _service;

        public PermissionController(IGenericService<PermissionDto, Permission> service)
        {
            _service = service;
        }
        public async Task<ActionResult> Index()
        {
            var permissionList = await _service.GetListAsync();
            return View(permissionList);
        }


        public async Task<IActionResult> Create()
        {
            PermissionDto model = new PermissionDto();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(PermissionDto itemDto)
        {
            itemDto.PermissionType = (PermissionType)Enum.ToObject(typeof(PermissionType), itemDto.PermissionTypeId);
            var permission = await _service.AddAsync(itemDto);
            if (permission != null)
            {
                TempData["success"] = "Permission has been successfully added.";
                return RedirectToAction("Index");
            }
            return Ok(permission);
        }


        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            model.PermissionTypeId = (int)model.PermissionType;
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(PermissionDto itemDto)
        {
            itemDto.PermissionType = (PermissionType)Enum.ToObject(typeof(PermissionType), itemDto.PermissionTypeId);
            var model = _service.Update(itemDto);

            if (model != null)
            {
                TempData["success"] = "Permission has been successfully updated.";
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            model.PermissionTypeId = (int)model.PermissionType;
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(PermissionDto itemDto)
        {
            _service.Delete(itemDto.Id);
            TempData["success"] = "Permission has been successfully deleted.";
            return RedirectToAction("Index");

        }

    }
}
