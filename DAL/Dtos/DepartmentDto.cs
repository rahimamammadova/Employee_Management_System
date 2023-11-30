using EMS_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class DepartmentDto:BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DepartmentType DepartmentType { get; set; }
    }
}
