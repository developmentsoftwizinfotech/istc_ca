using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.Account.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Account.Validation
{
    public class CreateLoginCommandValidator:AbstractValidator<CreateLoginCommand>
    {
        public CreateLoginCommandValidator()
        {
            RuleFor(v => v.RollNumber).NotEmpty().WithMessage("RollNumber is required").
                MaximumLength(20).WithMessage("Name must not exceeded 8 character");

            RuleFor(v => v.Password).NotEmpty().WithMessage("Password is required").
                MaximumLength(100).WithMessage("Password must not exceeded 100 character");
            
        }
    }
}
