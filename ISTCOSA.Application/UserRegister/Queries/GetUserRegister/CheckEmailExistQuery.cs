using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.UserRegister.Queries.GetUserRegister
{
    public class CheckEmailExistQuery:IRequest<UserRegisterDTOs>
    {
        public string Email { get; set; }
    }
}
