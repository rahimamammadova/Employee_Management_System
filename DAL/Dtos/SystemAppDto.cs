using EMS_DAL.Enums;
using EMS_DAL.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class SystemAppDto:BaseDto
    {
        public SystemAppDto()
        {
            this.SystemTypeEnumValues = EnumHelper<SystemType>.GetEnumValues();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display (Name="System type")]
        public int SystemTypeId { get; set; }
        public SystemType SystemType { get; set; }
        public List<EnumValueDto> SystemTypeEnumValues { get; set; }
        [Display (Name="System role type")]
        public Guid SystemAppRoleId { get; set; }
        public SystemAppRoleDto SystemAppRoleDto { get; set; }
    }
}
