using EMS_DAL.Enums;
using EMS_DAL.Helper;
using EMS_DAL.Models;
using EMS_DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class EmployeeDto : BaseDto
    {

        public EmployeeDto()
        {
            this.GenderTypeEnumValues = EnumHelper<GenderType>.GetEnumValues();
            this.PositionTypeEnumValues = EnumHelper<PositionType>.GetEnumValues();
        }

        [Display(Name = "Name")]
        public string Firstname { get; set; }
        [Display(Name = "Surname")]
        public string Lastname { get; set; }

        [Display(Name = "Gender Type")]
        public int GenderTypeId { get; set; }
        public GenderType GenderType { get; set; }

        [Display(Name = "Hire date")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }
        public Decimal Salary { get; set; }

        [Display(Name = "Position Type")]
        public int PositionTypeId { get; set; }
        public PositionType PositionType { get; set; }

        public List<EnumValueDto> GenderTypeEnumValues { get; set; }
        public List<EnumValueDto> PositionTypeEnumValues { get; set; }

        public string? UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public DepartmentDto DepartmentDto { get; set; }


        public string ProfilePicture { get; set; }
    }
}
