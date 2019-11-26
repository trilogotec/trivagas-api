using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Notify;
using TriVagas.Services.Requests;
using TriVagas.WebApi.Filters;

namespace TriVagas.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/{controller}")]
    [ApiController]
    public class OpportunityController : ApiController
    {
        private readonly IOpportunityService _opportunityService;
        private readonly IUserService _userService;
        private readonly IJWTService _jwtService;

        public OpportunityController(
            IOpportunityService opportunityService,
            IUserService userService,
            IJWTService jwtService,
            INotify notify) : base(notify)
        {
            _opportunityService = opportunityService;
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var opportunities = await _opportunityService.GetAll();

            return Response(opportunities);
        }

        [TypeFilter(typeof(JWTokenAuthFilter))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOpportunityRequest opportunity)
        {
            var claims = _jwtService.GetTokenClaims(Request.Headers["JWToken"]);
            var email = claims.First().Value;
            var user = await _userService.GetByEmail(email);

            if (user == null)
            {
                return Response(code: 404);
            }

            var createdOpportunity = await _opportunityService.Register(opportunity, user);

            if (createdOpportunity != null)
            {
                return Response(createdOpportunity, 201);
            }
            else
            {
                return Response(code: 400);
            }
        }

    }
}