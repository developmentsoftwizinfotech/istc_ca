using MediatR;

namespace ISTCOSA.Application.CommandAndQuries.Batches.Commands.CreateBatch
{
    public class CreateBatchCommands : IRequest<BatchDTO>
    {
        public int BatchNumber { get; set; }


    }
}
