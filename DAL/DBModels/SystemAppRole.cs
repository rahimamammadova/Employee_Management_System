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

        public Guid? SystemAppId { get; set; }
        public SystemApp SystemApp { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    }
}
