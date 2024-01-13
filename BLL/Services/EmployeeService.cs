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
    public class EmployeeService : GenericService<EmployeeDto, Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGenericRepository<Department> _departmentRepository;

        public EmployeeService(IGenericRepository<Employee> genericRepository,
            IMapper mapper, ILogger<GenericService<EmployeeDto, Employee>> logger,
            IGenericRepository<Department> departmentRepository,
            IEmployeeRepository employeeReposiroty)
            : base(genericRepository, mapper, logger)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeReposiroty;
        }

        //public async Task<List<EmployeeDto>> GetEmployeeDtosAsync()
        //{
        //    var employees = await _employeeRepository.GetListAsync();
        //    var employeDtos = _mapper.Map<List<EmployeeDto>>(employees);
        //    var departments = await _departmentRepository.GetListAsync();
        //    var departamentDtos = _mapper.Map<List<DepartmentDto>>(departments);
        //    return departamentDtos;
        //}

        public async Task<List<DepartmentDto>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetListAsync();
            var departamentDtos = _mapper.Map<List<DepartmentDto>>(departments);
            return departamentDtos;
        }

        public async Task<List<EmployeeDto>> GetEmployeeByDepartmentIdAsync(Guid id)
        {
            var employees = await _employeeRepository.GetByDepartmentIdAsync(id);
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
            return employeeDtos;
        }

        public async Task<EmployeeDto> GetEmployeeDetailByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

    }
}

