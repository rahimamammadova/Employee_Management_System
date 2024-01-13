using AutoMapper;
using EMS_DAL.DBModels;
using EMS_DAL.Dtos;
using EMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeSystemApp, EmployeeSystemAppDto>().ReverseMap();
            CreateMap<SystemApp,SystemAppDto>().ReverseMap();
            CreateMap<SystemAppRole,SystemAppRoleDto>().ReverseMap();
            CreateMap<Permission,PermissionDto>().ReverseMap();
            CreateMap<SystemAppRolePermission, SystemAppRolePermissionDto>().ReverseMap();
            CreateMap<SystemRole, SystemRoleDto>().ReverseMap();

        }
    }
}
