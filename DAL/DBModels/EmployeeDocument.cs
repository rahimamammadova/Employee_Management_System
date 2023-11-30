using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.DBModels
{
    public class EmployeeDocument:BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Url { get; set; }
    }
}
