using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Notify;
using TriVagas.Services.Requests;
using TriVagas.WebApi.Filters;

namespace TriVagas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ApiController
    {
        private readonly IClassService _classService;
        private readonly IJWTService _jwtService;
        private readonly IUserService _userService;

        public ClassController(IClassService classService,
            IUserService userService,
            INotify notify,
            IJWTService jwtService) : base(notify)
        {
            _classService = classService;
            _userService = userService;
            _jwtService = jwtService;
        }

        [TypeFilter(typeof(JWTokenAuthFilter))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassRequest request)
        {
            var claims = _jwtService.GetTokenClaims(Request.Headers["JWToken"]);
            var email = claims.First().Value;
            var user = await _userService.GetByEmail(email);

            if (user == null)
            {
                return Response(code: 404);
            }

            var createdClass = await _classService.Register(request, user);

            if (createdClass != null)
            {
                return Response(createdClass, 201);
            }
            else
            {
                return Response(code: 400);
            }
        }
    }
}