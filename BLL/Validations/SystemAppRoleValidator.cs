using EMS_DAL.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Validations
{
    public class SystemAppRoleValidator : AbstractValidator<SystemAppRoleDto>
    {
        public SystemAppRoleValidator()
        {
            RuleFor(d => d.Title).NotNull().WithMessage("Role title can't be null.")
                                .NotEmpty().WithMessage("Role title can't be empty.")
                                .MinimumLength(2).WithMessage("Role title can't contain less than 2 characters.")
                                .MaximumLength(16).WithMessage("Role title can't contain more than 50 characters.");
        }
    }
}
