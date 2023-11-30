using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Dtos
{
    public class EmployeeSystemAppDto:BaseDto
    {
        public Guid EmployeeId { get; set; }
        public Guid SystemAppId { get; set; }
    }
}
