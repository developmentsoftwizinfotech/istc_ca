using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.Country.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class CountryController : BaseAPIController
    {
        [HttpGet("GetAllCountries")]
        [ProducesResponseType(typeof(List<CountryDTO>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllCountries()
        {
            var countryList = await Mediator.Send(new GetAllCountriesQueries());
            if (countryList == null || !countryList.Any())
            {
                return NotFound("No countries found.");
            }
            return Ok(countryList);
        }
    }
}
