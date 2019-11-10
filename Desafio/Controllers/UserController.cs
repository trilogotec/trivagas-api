using AutoMapper;
using Desafio.Models;
using Desafio.Repository;
using Desafio.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Desafio.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserRepository _userRepository;
        private readonly UserCompanyRepository _userCompanyRepository;
        private readonly IMapper _mapper;

        public UserController(UserRepository userRepository,
                              UserCompanyRepository userCompanyRepository,
                              HttpContextAccessor acessor,
                              IMapper mapper) : base(acessor)
        {
            _userRepository = userRepository;
            _userCompanyRepository = userCompanyRepository;
            _mapper = mapper; 
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(RegisterUserViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage));
            }

            var usuario = _userRepository.Add(_mapper.Map<User>(user)); 

            if(usuario == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<UserViewModel>(usuario)); 
        }

        [HttpGet("represent-company/{companyId}")]
        public IActionResult RepresentCompany(int companyId)
        {
            var userCompany = _userCompanyRepository.Add(new UserCompany 
            {
                UserId = UserId, 
                CompanyId = companyId 
            });

            if(userCompany == null)
            {
                BadRequest();
            }

            return Ok();
        }
    }
}