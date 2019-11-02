using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using TriVagas.Application.Models;
using TriVagas.Services.Interfaces;

namespace TriVagas.Application.Controllers
{
    [Produces("application/json")]
    [Route("user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IOpportunityService _opportunityService;

        public UserController(IServiceProvider serviceProvider)
        {
            _opportunityService = serviceProvider.GetRequiredService<IOpportunityService>();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            return Ok(user);
        }
    }
}