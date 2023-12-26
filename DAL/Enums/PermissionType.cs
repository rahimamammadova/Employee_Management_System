using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Enums
{
    public enum PermissionType
    {
        Read=1,
        Write=2,
        Modify=3,
        [Description("Read and execute")]
        ReadExecute=4,
        [Description("Full Control")]
        FullControl=5
    }
}
