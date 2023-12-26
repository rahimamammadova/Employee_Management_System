using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class SystemAppRoleDto : BaseDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public Guid PermissionId { get; set; }
        public PermissionDto PermissionDto { get; set; }
        public Guid SystemAppId { get; set; }
    }
}
