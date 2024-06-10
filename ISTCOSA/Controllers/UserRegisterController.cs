﻿using ISTCOSA.Application.Batch.Commands.CreateBatch;
using ISTCOSA.Application.Batch.Queries.GetBatches;
using ISTCOSA.Application.UserProfile.Queries.GetUserProfiles;
using ISTCOSA.Application.UserRegister.Commands.CreateUserRegister;
using ISTCOSA.Application.UserRegister.Queries.GetUserRegister;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : BaseAPIController
    {
        private readonly ILogger<UserRegisterController> _logger;
        public UserRegisterController(ILogger<UserRegisterController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllUserProfiles")]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var UserProfiles = await Mediator.Send(new GetAllUserRegister());
            return Ok(UserProfiles);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserRegisterCommands createUserProfileCommands)
        {
            if (createUserProfileCommands == null)
            {
                _logger.LogWarning("CreateUser: Received null createUserProfileCommands");
                return NotFound();
            }
            _logger.LogInformation("CreateUser called with data: {@createUserProfileCommands}", createUserProfileCommands);
            var createUser = await Mediator.Send(createUserProfileCommands);
            return Ok(createUser);
        }

        [HttpGet("CheckEmailExists")]
        public async Task<IActionResult> CheckEmailExists(string Email)
        {
            var EmailExists = await Mediator.Send(new CheckEmailExistQuery { Email = Email });
            return Ok(EmailExists);
        }

        [HttpGet("CheckPhoneNumberExists")]
        public async Task<IActionResult> CheckPhoneNumberExists(string phoneNumber)
        {
            var phoneExists = await Mediator.Send(new CheckPhoneNumberExistQuery { PhoneNumber = phoneNumber });
            return Ok(phoneExists);
        }
    }
}
