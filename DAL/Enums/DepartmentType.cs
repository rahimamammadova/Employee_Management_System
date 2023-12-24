using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Enums
{
    public enum DepartmentType
    {
        [Description("Strategic Department")]
        Strategic =1,
        [Description("Administrative Department")]
        Administrative =2
    }
}
