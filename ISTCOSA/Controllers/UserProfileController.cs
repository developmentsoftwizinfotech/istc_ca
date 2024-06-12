using ISTCOSA.Application.CommandAndQuries.UserProfile.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : BaseAPIController
    {
        
        [HttpPut("UpdateUserProfile{id}")]
        public async Task<IActionResult> UpdateUserProfile(string id, [FromBody] UpdateUserProfileCommand updateUserProfileCommand)
        {
            if (id == null || updateUserProfileCommand == null)
            {
                return BadRequest("Invalid User.");
            }
            var updatedUserprofile = await Mediator.Send(updateUserProfileCommand);
            if (updatedUserprofile == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating batch.");
            }
            return Ok(updatedUserprofile);
        }

    }
}
