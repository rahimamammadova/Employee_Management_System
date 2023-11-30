using AutoMapper;
using EMS_BLL.Services.Interfaces;
using EMS_DAL.DBModels;
using EMS_DAL.Dtos;
using EMS_DAL.Models;
using EMS_DAL.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Services
{
//    public class EmployeeService : GenericService<EmployeeDto, Employee>, IEmployeeService
//    {
//        private readonly IEmployeeRepository _employeeRepository;
//        private readonly IGenericRepository<Department> _departmentRepository;
//        private readonly IGenericRepository<EmployeeDocument> _documentReposiroty;

//        public EmployeeService(IGenericRepository<Employee> genericRepository,
//            IMapper mapper, ILogger<GenericService<EmployeeDto, Employee>> logger,
//            IGenericRepository<Department> departmentRepository,
//            IEmployeeRepository employeeReposiroty,
//            IGenericRepository<EmployeeDocument> documentRepository)
//            : base(genericRepository, mapper, logger)
//        {
//            _departmentRepository = departmentRepository;
//            _employeeRepository = employeeReposiroty;
//            _documentReposiroty = documentRepository;
//        }

//        public async Task<List<DepartmentDto>> GetDepartmentsAsync()
//        {
//            var departments = await _departmentRepository.GetListAsync();
//            var departamentDtos = _mapper.Map<List<DepartmentDto>>(departments);
//            return departamentDtos;
//        }
//        public async Task<List<EmployeeDto> GetEmployeesByDepartmentIdAsync(Guid id){}
//}
}
