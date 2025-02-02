﻿using ISTCOSA.Application.Common.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Account.Commands
{
    public class CreateResetPasswordCommand:IRequest<ResetPasswordDTO>
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}
