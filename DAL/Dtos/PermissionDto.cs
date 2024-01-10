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
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
