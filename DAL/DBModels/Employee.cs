using EMS_DAL.DBModels;
using EMS_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Models
{
    public class Employee : BaseEntity
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public GenderType GenderType { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public Decimal Salary { get; set; }
        public PositionType PositionType { get; set; }

        public string? UserId { get; set; }

        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }

        public string ProfilePicture { get; set; }
        public ICollection<EmployeeDocument> EmployeeDocuments { get; set; } = new List<EmployeeDocument>();
        public ICollection<SystemApp> SystemApps { get; set; }= new List<SystemApp>();
        public ICollection<EmployeeSystemApp> EmployeeSystemApps { get; set; } = new List<EmployeeSystemApp>();

    }
}
