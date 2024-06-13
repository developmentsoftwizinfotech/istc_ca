using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Account.Commands
{
    public class CreateLoginCommand : IRequest<LoginDTO>
    {
        
        public string RollNumber { get; set; }
        public string Password { get; set; }
    }
}
