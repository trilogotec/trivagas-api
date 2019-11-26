using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Notify;
using TriVagas.Services.Requests;
using TriVagas.WebApi.Filters;

namespace TriVagas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IJWTService _jwtService;
        private readonly IUserService _userService;

        public CompanyController(
            ICompanyService companyService,
            IUserService userService,
            INotify notify,
            IJWTService jwtService) : base(notify)
        {
            _companyService = companyService;
            _userService = userService;
            _jwtService = jwtService;
        }


        [TypeFilter(typeof(JWTokenAuthFilter))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyRequest company)
        {
            var claims = _jwtService.GetTokenClaims(Request.Headers["JWToken"]);
            var email = claims.First().Value;
            var user = await _userService.GetByEmail(email);

            if (user == null)
            {
                return Response(code:404);
            }

            var createdCompany = await _companyService.Register(company, user);

            if (createdCompany != null)
            {
                return Response(createdCompany, 201);
            }
            else
            {
                return Response(code:400);
            }
        }
    }
}