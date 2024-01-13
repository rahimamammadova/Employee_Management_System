using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.DBModels
{
    public class SystemRole:BaseEntity
    {
        public Guid SystemAppId { get; set; }
        public Guid RoleId { get; set;}
    }
}
