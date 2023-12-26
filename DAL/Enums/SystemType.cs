using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DAL.Enums
{
    public enum SystemType
    {
        [Description("Simulator application")]
        Simulator=1,
        [Description("Monitoring application")]
        Monitoring =2,
        [Description("Security application")]
        Security =3,
        [Description("Management application")]
        Management =4,
        [Description("Enterprise resource planning application")]
        ERP =5,
        [Description("Supply chain management application")]
        SCM =6,
        [Description("Customer relationship management application")]
        CRM =7

    }
}
