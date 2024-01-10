using AutoMapper;
using EMS_BLL.Services.Interfaces;
using EMS_DAL.DBModels;
using EMS_DAL.Dtos;
using EMS_DAL.Models;
using EMS_DAL.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Services
{
    public class SystemAppRoleService:GenericService<SystemAppRoleDto, SystemAppRole>,ISystemAppRoleService
    {

        private readonly IGenericRepository<SystemAppRole> _roleRepository;

        public SystemAppRoleService(IGenericRepository<SystemAppRole> genericRepository,
            IMapper mapper, ILogger<GenericService<SystemAppRoleDto, SystemAppRole>> logger)
            : base(genericRepository, mapper, logger)
        {
            _roleRepository = genericRepository;
        }
        public async Task<List<SystemAppRoleDto>> GetSystemAppRoleBySystemIdAsync(Guid id)
        {
            var roles = await _roleRepository.GetListAsync();
            var roleDtos = _mapper.Map<List<SystemAppRoleDto>>(roles);
            return roleDtos;
        }
    }
}
