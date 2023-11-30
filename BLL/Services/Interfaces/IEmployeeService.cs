using EMS_DAL.Dtos;
using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Services.Interfaces
{
    public interface IEmployeeService : IGenericService<EmployeeDto,Employee>
    {
        public Task<List<DepartmentDto>> GetDepartmentsAsync();
        public Task<List<EmployeeDto>> GetEmployeeDepartmentIdAsync(Guid id);
        public Task<EmployeeDto> GetEmployeeDetailByIdAsync(Guid id);
    }
}
