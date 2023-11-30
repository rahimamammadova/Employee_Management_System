using EMS_DAL.Data;
using EMS_DAL.Models;
using EMS_DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Repository
{
    public class EmployeeRepository: GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbIdentityContext dbContext) : base(dbContext)
        {

        }

        public async Task <List<Employee>> GetByDepartmentIdAsync(Guid id)
        {
            IQueryable<Employee> employees=_dbContext.Employees.Where(e=>e.DepartmentId==id);
            return employees.ToList();
        }
    }
}
