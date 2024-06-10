using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.EmploymentType.Commands
{
    public class CreateUserProfessionCommand:IRequest<ProfessionDTO>
    {
        public string Name { get; set; }
    }
}
