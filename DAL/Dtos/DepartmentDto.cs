using EMS_DAL.Enums;
using EMS_DAL.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class DepartmentDto:BaseDto
    {
        public DepartmentDto() {
            this.DepTypeEnumValues = EnumHelper<DepartmentType>.GetEnumValues();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Department Type")]
        public int DepTypeId { get; set; }
        public DepartmentType DepartmentType { get; set; }
        public List<EnumValueDto> DepTypeEnumValues { get; set; }
    }
}
