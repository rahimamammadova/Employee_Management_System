using EMS_BLL.Helper;
using EMS_BLL.Services.Interfaces;
using EMS_DAL.Dtos;
using EMS_DAL.Enums;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IGenericService<DepartmentDto, Department> _service;

        public DepartmentController(IGenericService<DepartmentDto, Department> service)
        {
            _service = service;
        }
        public async Task<ActionResult> Index()
        {
            var depList= await _service.GetListAsync();
            return View(depList);
        }
        

        public async Task<IActionResult> Create()
        {
            DepartmentDto model = new DepartmentDto();        
            return View(model);
  
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDto itemDto)
        {
            itemDto.DepartmentType = (DepartmentType)Enum.ToObject(typeof(DepartmentType), itemDto.DepTypeId);
            var department = await _service.AddAsync(itemDto);
            if (department != null)
            {
                TempData["success"] = "Department has been successfully added.";
                return RedirectToAction("Index");
            }
            return Ok(department);
        }


        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            model.DepTypeId = (int)model.DepartmentType;
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(DepartmentDto itemDto)
        {
            itemDto.DepartmentType = (DepartmentType)Enum.ToObject(typeof(DepartmentType), itemDto.DepTypeId);
            var model = _service.Update(itemDto);
      
            if (model != null)
            {
                TempData["success"] = "Department has been successfully updated.";
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            model.DepTypeId = (int)model.DepartmentType;
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(DepartmentDto itemDto)
        {
            _service.Delete(itemDto.Id);
            TempData["success"] = "Department has been successfully deleted.";
            return RedirectToAction("Index");


        }
  
    }
}
