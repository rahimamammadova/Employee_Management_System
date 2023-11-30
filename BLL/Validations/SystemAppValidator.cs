using EMS_DAL.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Validations
{
    public class SystemAppValidator : AbstractValidator<SystemAppDto>
    {
        public SystemAppValidator()
        {
            RuleFor(d => d.Title).NotNull().WithMessage("System application title can't be null.")
                                .NotEmpty().WithMessage("System application title can't be empty.")
                                .MinimumLength(2).WithMessage("System application title can't contain less than 2 characters.")
                                .MaximumLength(16).WithMessage("System application title can't contain more than 50 characters.");
        }
    }
}
