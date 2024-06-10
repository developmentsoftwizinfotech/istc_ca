﻿using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.Company.Queries;
using ISTCOSA.Application.Industry.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : BaseAPIController
    {
        [HttpGet("GetAllIndustries")]
        [ProducesResponseType(typeof(List<IndustryDTO>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllIndustries()
        {
            var IndustryList = await Mediator.Send(new GetAllIndustriesQuery());
            if (IndustryList == null || !IndustryList.Any())
            {
                return NotFound("No IndustryList found.");
            }
            return Ok(IndustryList);
        }
    }
}
