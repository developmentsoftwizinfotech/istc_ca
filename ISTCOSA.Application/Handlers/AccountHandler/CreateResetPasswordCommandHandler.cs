using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Account.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ISTCOSA.Infrastructure.Handlers.AccountHandler
{
    public class CreateResetPasswordCommandHandler : IRequestHandler<CreateResetPasswordCommand, ResetPasswordDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<CreateResetPasswordCommandHandler> _logger;

        public CreateResetPasswordCommandHandler(IApplicationDBContext context, IMapper mapper, UserManager<IdentityUser> userManager,ILogger<CreateResetPasswordCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<ResetPasswordDTO> Handle(CreateResetPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user == null)
                {
                    _logger.LogError("User with username {UserName} not found.", request.UserName);
                    throw new Exception("User not found.");
                }

                var decodedToken = WebUtility.UrlDecode(request.Token);

                var resetPassResult = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

                if (resetPassResult.Succeeded)
                {
                    var resetPasswordDTO = new ResetPasswordDTO
                    {
                        UserName = request.UserName,
                        NewPassword = request.NewPassword,
                        Token = request.Token
                    };

                    _logger.LogInformation("Password reset successful for user {UserName} {Token}.", request.UserName,request.Token);
                    return resetPasswordDTO;
                }

                var errors = string.Join(", ", resetPassResult.Errors.Select(e => e.Description));
                _logger.LogError("Password reset failed for user {UserName}: {Errors}", request.UserName, errors);
                throw new Exception($"Password reset failed: {errors}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while handling password reset for user {UserName}.", request.UserName);
                throw;
            }
        }
    }
}
