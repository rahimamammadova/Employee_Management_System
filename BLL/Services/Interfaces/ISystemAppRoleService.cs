using EMS_DAL.Dtos;
using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Services.Interfaces
{
    public interface ISystemAppRoleService : IGenericService<SystemAppRoleDto, SystemAppRole>
    {
        public Task<List<SystemAppRoleDto>> GetSystemAppRoleBySystemIdAsync(Guid id);
    }
}
