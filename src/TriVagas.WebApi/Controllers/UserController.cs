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
        public UserController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userRequest)
        {
            if (await _userService.GetByEmail(userRequest.Email) != null)
            {
                return BadRequest("E-Mail já registrado");
            }

            var registeredUser = await _userService.Regiser(userRequest);
            return Ok(registeredUser);
        }
    }
}