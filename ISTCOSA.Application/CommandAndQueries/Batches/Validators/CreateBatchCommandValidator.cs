 

namespace ISTCOSA.Application.CommandAndQuries.Batches.Validators
{
    public class CreateBatchCommandValidator:AbstractValidator<CreateBatchCommand>
    {
        public CreateBatchCommandValidator()
        {
            RuleFor(v => v.BatchNumber).NotEmpty().WithMessage("BatchNumber is required");
           
        }
    }
}
