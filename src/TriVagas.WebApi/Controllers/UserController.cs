using Microsoft.AspNetCore.Mvc;
using TriVagas.Services.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;
using TriVagas.Services.Interfaces;

namespace TriVagas.Application.Controllers
{
    [Produces("application/json")]
    [Route("user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginRequest user)
        {
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserRegisterRequest user)
        {
            return Ok(user);
        }
    }
}