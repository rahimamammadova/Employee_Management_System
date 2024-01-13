using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class SystemAppRolePermissionDto: BaseDto
    {
        public Guid RoleId { get; set; }
        [Display(Name = "Role Title")]
        public string RoleTitle { get; set; }
        [Display (Name="Permission")]
        public Guid PermissionId { get; set; }
        public string  PermissionTitle { get; set; }
    }
}
