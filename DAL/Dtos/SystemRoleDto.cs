using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class SystemRoleDto:BaseDto
    {
        public Guid SystemAppId { get; set; }
        [Display (Name ="System title")]
        public string SystemAppTitle { get; set; }
        public Guid RoleId { get; set; }
        public string RoleTitle { get; set; }
    }
}
