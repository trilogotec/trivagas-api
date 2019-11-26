using Microsoft.AspNetCore.Mvc;
using TriVagas.Services.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;
using TriVagas.Services.Interfaces;
using System.Threading.Tasks;
using TriVagas.Services.Responses;
using TriVagas.Services.Notify;

namespace TriVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ApiController
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService, INotify _notify) : base(_notify)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            var loggedUser = await _sessionService.Login(user);
            if (loggedUser == null) return BadRequest("E-mail ou senha inválidos");

            return Response(loggedUser, 200);
        }
    }
}