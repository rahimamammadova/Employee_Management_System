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
    public class PermissionDto : BaseDto
    {
        public PermissionDto()
        {
            this.PermissionTypeEnumValues = EnumHelper<PermissionType>.GetEnumValues();
        }
        public string Title { get; set; }
        [Display(Name ="Permission Type")]
        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }
        public List<EnumValueDto> PermissionTypeEnumValues { get; set; }
        public string Description { get; set; }
        public Guid SystemAppRoleId { get; set; }
    }
}
