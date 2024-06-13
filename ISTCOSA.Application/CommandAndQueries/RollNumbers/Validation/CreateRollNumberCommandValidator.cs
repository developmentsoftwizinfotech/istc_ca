using FluentValidation;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Commands.CreateRollNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.RollNumbers.Validation
{
    public class CreateRollNumberCommandValidator:AbstractValidator<CreateRollNumberCommand>
    {
        public CreateRollNumberCommandValidator()
        {
            RuleFor(v => v.RollNumbers).NotEmpty().WithMessage("RollNumbers is required");
            RuleFor(v => v.BatchId).NotEmpty().WithMessage("BatchId is required");

        }
    }
}
