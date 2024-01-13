using EMS_BLL.Services.Interfaces;
using EMS_DAL.DBModels;
using EMS_DAL.Dtos;
using EMS_DAL.Enums;
using EMS_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IGenericService<EmployeeDto, Employee> _service;
        private readonly IGenericService<DepartmentDto, Department> _depService;
        private readonly IGenericService<SystemAppDto, SystemApp> _systemService;
        private readonly IGenericService<EmployeeSystemAppDto, EmployeeSystemApp> _employeeSystemService;
        private readonly IHostingEnvironment _hostingEnvironment;


        public EmployeeController(IGenericService<EmployeeDto, Employee> service, IGenericService<DepartmentDto, Department> depService,
            IGenericService<EmployeeSystemAppDto, EmployeeSystemApp> employeeSystemService, IGenericService<SystemAppDto, SystemApp> systemService,
            IHostingEnvironment hostingEnvironment)
        {
            _service = service;
            _depService = depService;
            _employeeSystemService= employeeSystemService;
            _systemService = systemService;
            _hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> Create(EmployeeDto itemDto, IFormFile file)
        {
            string wwwRootPath = _hostingEnvironment.WebRootPath;
            string folderPath = @"Documents\ProfilePicture";
            string fullPath = Path.Combine(wwwRootPath, folderPath);

                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                string realPath = Path.Combine(fullPath, fileName + extension);

                using (var fileStream = new FileStream(realPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

            string DocumentUrl = @"Documents/ProfilePicture/" + fileName + extension;
            itemDto.ProfilePicture = DocumentUrl;

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
            TempData["profilePic"] = model.ProfilePicture;
            return View(model);

        }

        [HttpPost]
        public IActionResult Update(EmployeeDto itemDto, IFormFile file)
        {
            if (file != null)
            {
                string wwwRootPath = _hostingEnvironment.WebRootPath;
                string folderPath = @"Documents\ProfilePicture";
                string fullPath = Path.Combine(wwwRootPath, folderPath);

                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                string realPath = Path.Combine(fullPath, fileName + extension);

                using (var fileStream = new FileStream(realPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                string DocumentUrl = @"Documents/ProfilePicture/" + fileName + extension;
                itemDto.ProfilePicture = DocumentUrl;
            }
            else {
                if (TempData.ContainsKey("profilePic"))
                {
                    itemDto.ProfilePicture = TempData["profilePic"].ToString();
                }
            }

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

        public async Task<IActionResult> ShowSystemInfo(Guid id)
        {
            List<EmployeeSystemAppDto> employeeSystemDtoList = new List<EmployeeSystemAppDto>();
            var employeeSystems = await _employeeSystemService.GetListAsync();
            var employeeSystemList = employeeSystems.Where(x => x.EmployeeId == id).ToList();

            TempData["EmployeeId"] = id;
            foreach (var employeeSystem in employeeSystemList)
            {
                var system = await _systemService.GetByIdAsync(employeeSystem.SystemAppId);
                employeeSystem.SystemAppTitle = system.Title; 
                employeeSystemDtoList.Add(employeeSystem);
            }
            return View(employeeSystemDtoList);

        }


        public async Task<IActionResult> AssignSystem()
        {
            Guid employeeId = Guid.Empty;
            if (TempData.ContainsKey("EmployeeId"))
            {
                employeeId = Guid.Parse(TempData["EmployeeId"].ToString());
            }

            EmployeeSystemAppDto model = new EmployeeSystemAppDto();

            var employee = await _service.GetByIdAsync(employeeId);
            model.EmployeeName = employee.Firstname;
            model.EmployeeId = employee.Id;

            ViewBag.SystemAppDtos = await _systemService.GetListAsync();

            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> AssignSystem(EmployeeSystemAppDto itemDto)
        {
            var model = _employeeSystemService.AddAsync(itemDto);

            if (model != null)
            {
                TempData["success"] = "Employee's system has been successfully updated.";
                return RedirectToAction("Index");
            }
            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> DeleteSystem(Guid id)
        {
            _systemService.Delete(id);
            TempData["success"] = "Employee's system has been successfully deleted.";
            return RedirectToAction("Index");

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
