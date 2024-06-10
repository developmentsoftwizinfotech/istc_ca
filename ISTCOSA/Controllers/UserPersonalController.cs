using ISTCOSA.Application.Batches.Queries.GetBatchById;
using ISTCOSA.Application.UserPersonal.Commands;
using ISTCOSA.Application.UserPersonal.Queries;
using ISTCOSA.Application.UserRegister.Commands.CreateUserRegister;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPersonalController : BaseAPIController
    {
        private readonly ILogger<UserRegisterController> _logger;
        public UserPersonalController(ILogger<UserRegisterController> logger)
        {
            _logger = logger;
        }
        

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserPersonal(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid UserPersonal ID.");
            }
            var Personaldetail = await Mediator.Send(new UserPersonalByIdQuery { Id = id });
            if (Personaldetail == null)
            {
                return NotFound("Personal detail not found.");
            }
            return Ok(Personaldetail);
        }

        [HttpPost("CreateUserPersonal")]
        public async Task<IActionResult> CreateUserPersonal(CreateUserPersonalCommand createUserPersonalCommand)
        {
            if (createUserPersonalCommand == null)
            {
                _logger.LogWarning("CreateUser: Received null createUserProfileCommands");
                return NotFound();
            }
            _logger.LogInformation("CreateUser called with data: {@createUserProfileCommands}", createUserPersonalCommand);
            var UserPersonal = await Mediator.Send(createUserPersonalCommand);
            return Ok(UserPersonal);
        }




    }
}
