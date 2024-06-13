using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.UserRegister.Commands.CreateUserRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserRegister.Validation
{
    public class CreateUserRegisterCommandValidator:AbstractValidator<CreateUserRegisterCommands>
    {
        public CreateUserRegisterCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(v => v.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required");
            RuleFor(v => v.DateOfBirth).NotEmpty().WithMessage("Date Of Birth is required");
            RuleFor(v => v.CityId).NotEmpty().WithMessage("City is required");
            RuleFor(v => v.FullName).NotEmpty().WithMessage("FullName is required");
            RuleFor(v => v.Gender).NotEmpty().WithMessage("Gender is required");
            RuleFor(v => v.Images).NotEmpty().WithMessage("Image is required");
            
        }
    }
}
