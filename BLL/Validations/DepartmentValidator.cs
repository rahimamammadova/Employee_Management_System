using EMS_DAL.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Validations
{
    public class DepartmentValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Title).NotNull().WithMessage("Department title can't be null.")
                        .NotEmpty().WithMessage("Department title can't be empty.")
                        .MinimumLength(2).WithMessage("Department title can't contain less than 2 characters.")
                        .MaximumLength(16).WithMessage("Department title can't contain more than 128 characters.");
        }
    }
}
