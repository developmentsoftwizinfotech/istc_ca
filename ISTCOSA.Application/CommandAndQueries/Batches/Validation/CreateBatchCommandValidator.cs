using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Batches.Validation
{
    public class CreateBatchCommandValidator:AbstractValidator<CreateBatchCommands>
    {
        public CreateBatchCommandValidator()
        {
            RuleFor(v => v.BatchNumber).NotEmpty().WithMessage("BatchNumber is required");
           
        }
    }
}
