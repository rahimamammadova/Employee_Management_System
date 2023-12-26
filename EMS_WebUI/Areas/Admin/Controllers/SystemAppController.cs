using EMS_BLL.Services.Interfaces;
using EMS_DAL.Dtos;
using EMS_DAL.Enums;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SystemAppController : Controller
    {
        private readonly IGenericService<SystemAppDto, SystemApp> _service;
        private readonly IGenericService<SystemAppRoleDto, SystemAppRole> _roleService;


        public SystemAppController(IGenericService<SystemAppDto, SystemApp> service, IGenericService<SystemAppRoleDto, SystemAppRole> roleService)
        {
            _service = service;
            _roleService = roleService;
        }
        public async Task<ActionResult> Index()
        {
            var systemList = await _service.GetListAsync();

            foreach (var item in systemList)
            {
                var role = await _roleService.GetByIdAsync(item.SystemAppRoleId);
                item.SystemAppRoleDto = new SystemAppRoleDto()
                {
                    Id = role.Id,
                    Title = role.Title
                };
            }

            return View(systemList);
        }


        public async Task<IActionResult> Create()
        {

            SystemAppDto model = new SystemAppDto();
            ViewBag.SystemAppRoleDtos = await _roleService.GetListAsync();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(SystemAppDto itemDto)
        {
            itemDto.SystemType = (SystemType)Enum.ToObject(typeof(SystemType), itemDto.SystemTypeId);
            var system = await _service.AddAsync(itemDto);
            if (system != null)
            {
                TempData["success"] = "System has been successfully added.";
                return RedirectToAction("Index");
            }
            return Ok(system);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            model.SystemTypeId = (int)model.SystemType;
            ViewBag.SystemAppRoleDtos = await _roleService.GetListAsync();
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(SystemAppDto itemDto)
        {
            itemDto.SystemType = (SystemType)Enum.ToObject(typeof(SystemType), itemDto.SystemTypeId);
            var model = _service.Update(itemDto);

            if (model != null)
            {
                TempData["success"] = "System has been successfully updated.";
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            model.SystemTypeId = (int)model.SystemType;
            ViewBag.SystemAppRoleDtos = await _roleService.GetListAsync();
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(SystemAppDto itemDto)
        {
            _service.Delete(itemDto.Id);
            TempData["success"] = "System has been successfully deleted.";
            return RedirectToAction("Index");


        }
    }
}
