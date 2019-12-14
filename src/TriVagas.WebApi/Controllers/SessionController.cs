using Microsoft.AspNetCore.Mvc;
using TriVagas.Services.Requests;
using Microsoft.Extensions.DependencyInjection;
using System;
using TriVagas.Services.Interfaces;
using System.Threading.Tasks;
using TriVagas.Services.Responses;
using TriVagas.Services.Notify;
using TriVagas.WebApi.Config;

namespace TriVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ApiController
    {
        //private readonly ISessionService _sessionService;
        private readonly Authentication _authentication;

        public SessionController(Authentication authentication, INotify _notify) : base(_notify)
        {
            //_sessionService = sessionService;
            _authentication = authentication;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            var loggedUser = await _authentication.Login(user);

            return Response(loggedUser, 200);
        }
    }
}