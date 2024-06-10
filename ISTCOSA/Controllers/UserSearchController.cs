﻿using ISTCOSA.Application.UserSearch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSearchController :BaseAPIController
    {
        [HttpPost]
        public async Task<IActionResult>Search(UserSearchCommand userSearch)

        {
            var SearchList =await Mediator.Send(userSearch);
            return Ok(SearchList);
        }
    }
}
