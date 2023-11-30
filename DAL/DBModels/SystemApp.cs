using EMS_DAL.DBModels;
using EMS_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Models
{
    public class SystemApp : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public SystemType SystemType { get; set; }
        public ICollection<SystemAppRole> SystemAppRoles { get; set; } = new List<SystemAppRole>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<EmployeeSystemApp> EmployeeSystemApps { get; set; } = new List<EmployeeSystemApp>();
    }
}
