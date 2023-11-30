using EMS_DAL.Enums;
using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class EmployeeDto:BaseDto
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public GenderType GenderType { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public Decimal Salary { get; set; }
        public PositionType PositionType { get; set; }

        public Guid UserId { get; set; }
        public Guid DepartmentId { get; set; }

        public string ProfilePicture { get; set; }
    }
}
