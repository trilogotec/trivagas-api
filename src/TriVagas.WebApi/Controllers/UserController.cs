using Microsoft.AspNetCore.Mvc;
using TriVagas.Services.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;
using TriVagas.Services.Interfaces;
using System.Threading.Tasks;

namespace TriVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            var loggedUser = await _userService.Login(user);
            if(loggedUser == null) return BadRequest("E-mail ou senha inválidos");
            return Ok(loggedUser);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRequest)
        {
            if (await _userService.GetByEmail(userRequest))
            {
                return BadRequest("E-Mail já registrado");
            }

            var registeredUser = await _userService.Regiser(userRequest);
            return Ok(registeredUser);
        }
    }
}