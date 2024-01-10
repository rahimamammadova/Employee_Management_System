using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Models
{
    public class SystemAppRole : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
