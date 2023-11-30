using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.DBModels
{
    public class EmployeeSystemApp:BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid SystemAppId { get; set; }
        public SystemApp SystemApp { get; set; }
    }
}
