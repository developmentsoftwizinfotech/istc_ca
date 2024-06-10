﻿using ISTCOSA.Application.Batch.Commands.CreateBatch;
using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Application.EmploymentType.Commands;
using ISTCOSA.Application.EmploymentType.Queries;
using ISTCOSA.Application.Industry.Queries;
using ISTCOSA.Application.UserEmployment.Commands;
using ISTCOSA.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : BaseAPIController
    {
        [HttpGet("GetAllProfession")]
        [ProducesResponseType(typeof(List<ProfessionDTO>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllProfession()
        {
            var ProfessionList = await Mediator.Send(new GetAllProfessionListQuery());
            if (ProfessionList == null || !ProfessionList.Any())
            {
                return NotFound("No ProfessionList found.");
            }
            return Ok(ProfessionList);
        }

        [HttpPost("CreateProfession")]
        public async Task<IActionResult> CreateProfession([FromBody] CreateUserProfessionCommand createCommand)
        {
            if (createCommand == null)
            {
                return BadRequest("Batch data is null.");
            }
            var CreateProfessions = await Mediator.Send(createCommand);
            if (CreateProfessions == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating Professions.");
            }
            return Ok(CreateProfessions);
        }
    }
}
