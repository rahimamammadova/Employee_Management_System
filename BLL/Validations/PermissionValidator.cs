using EMS_DAL.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Validations
{
    public class PermissionValidator : AbstractValidator<PermissionDto>
    {
        public PermissionValidator()
        {
            RuleFor(d => d.Title).NotNull().WithMessage("Permission title can't be null.")
                            .NotEmpty().WithMessage("Permission title can't be empty.")
                            .MinimumLength(2).WithMessage("Permission title can't contain less than 2 characters.")
                            .MaximumLength(16).WithMessage("Permission title can't contain more than 50 characters.");
        }
    }
}
