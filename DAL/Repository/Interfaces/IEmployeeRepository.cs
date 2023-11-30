using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public Task<List<Employee>> GetByDepartmentIdAsync(Guid id);
    }
}
