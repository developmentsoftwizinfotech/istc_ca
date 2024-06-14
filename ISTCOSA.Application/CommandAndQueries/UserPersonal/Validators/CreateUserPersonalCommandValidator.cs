using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.UserPersonal.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserPersonal.Validation
{
    public class CreateUserPersonalCommandValidator:AbstractValidator<CreateUserPersonalCommand>
    {
        public CreateUserPersonalCommandValidator()
        {
            RuleFor(v => v.ISTCAbout).NotEmpty().WithMessage("ISTCAbout is required");
            RuleFor(v => v.MaritalStatus).NotEmpty().WithMessage("MaritalStatus is required");
            RuleFor(v => v.WhatsappNumber).NotEmpty().WithMessage("WhatsApp Number is required");
            RuleFor(v => v.Address).NotEmpty().WithMessage("WhatsApp Number is required");
        }
    }
}
