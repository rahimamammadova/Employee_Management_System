using EMS_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class PermissionDto : BaseDto
    {
        public string Title { get; set; }
        public PermissionType PermissionType { get; set; }
        public string Description { get; set; }
        public Guid SystemAppRoleId { get; set; }
    }
}
