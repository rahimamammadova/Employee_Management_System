using EMS_DAL.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_BLL.Validations
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(f => f.Firstname).NotNull().WithMessage("Firstname can't be null. Please enter firstname.")
                    .NotEmpty().WithMessage("Firstname can't be empty. Please enter firstname.")
                    .MinimumLength(2).WithMessage("Name can't contain less than 2 characters.")
                    .MaximumLength(256).WithMessage("Name can't contain more than 256 characters.");
            RuleFor(l => l.LastName).NotNull().WithMessage("Lastname can't be null. Please enter lastname.")
                    .NotEmpty().WithMessage("Lastname can't be empty. Please enter lastname.")
                    .MinimumLength(2).WithMessage("Surname can't contain less than 2 characters.")
                    .MaximumLength(256).WithMessage("Surname can't contain more than 256 characters.");
            RuleFor(g => g.GenderType).NotNull().WithMessage("Gender can't be null.")
                    .NotEmpty().WithMessage("Gender can't be empty.");
            RuleFor(s => s.Salary).NotNull().WithMessage("Salary can't be null.")
                .GreaterThan(500).WithMessage("Salary can't be less than 500")
                .LessThan(20000).WithMessage("Salary can't be more than 20k.");
        }
    }
}
