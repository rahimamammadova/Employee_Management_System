using EMS_BLL.Services.Interfaces;
using EMS_DAL.Dtos;
using EMS_DAL.Enums;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IGenericService<EmployeeDto, Employee> _service;
        private readonly IGenericService<DepartmentDto, Department> _depService;


        public EmployeeController(IGenericService<EmployeeDto, Employee> service, IGenericService<DepartmentDto, Department> depService)
        {
            _service = service;
            _depService = depService;
        }
        public async Task<ActionResult> Index()
        {
            var empList = await _service.GetListAsync();

            foreach (var item in empList)
            {
                var department= await _depService.GetByIdAsync(item.DepartmentId);
                item.DepartmentDto = new DepartmentDto()
                {
                    Id = department.Id,
                    Title = department.Title
                };
            }

            return View(empList);
        }


        public async Task<IActionResult> Create()
        {

            EmployeeDto model = new EmployeeDto();
            ViewBag.DepartmentDtos = await _depService.GetListAsync();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto itemDto)
        {
            itemDto.GenderType = (GenderType)Enum.ToObject(typeof(GenderType), itemDto.GenderTypeId);
            itemDto.PositionType = (PositionType)Enum.ToObject(typeof(PositionType), itemDto.PositionTypeId);
            var employee = await _service.AddAsync(itemDto);
            if (employee != null)
            {
                TempData["success"] = "Employee has been successfully added.";
                return RedirectToAction("Index");
            }
            return Ok(employee);
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            model.GenderTypeId = (int)model.GenderType;
            model.PositionTypeId = (int)model.PositionType;
            ViewBag.DepartmentDtos = await _depService.GetListAsync();
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(EmployeeDto itemDto)
        {
            itemDto.GenderType = (GenderType)Enum.ToObject(typeof(GenderType), itemDto.GenderTypeId);
            itemDto.PositionType = (PositionType)Enum.ToObject(typeof(PositionType), itemDto.PositionTypeId);
            var model = _service.Update(itemDto);

            if (model != null)
            {
                TempData["success"] = "Employee has been successfully updated.";
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _service.GetByIdAsync(id);
            model.GenderTypeId = (int)model.GenderType;
            model.PositionTypeId = (int)model.PositionType;
            ViewBag.DepartmentDtos = await _depService.GetListAsync();
            return View(model);

        }
        [HttpPost]
        public IActionResult Delete(EmployeeDto itemDto)
        {
            _service.Delete(itemDto.Id);
            TempData["success"] = "Employee has been successfully deleted.";
            return RedirectToAction("Index");


        }

    }
}
