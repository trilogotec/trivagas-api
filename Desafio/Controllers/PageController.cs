using AutoMapper;
using Desafio.Models;
using Desafio.Repository;
using Desafio.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Controllers
{
    [Route("api/page")]
    [ApiController]
    [Authorize]
    public class PageController : BaseController
    {
        private readonly PageRepository _pageRepository;
        private readonly UserCompanyRepository _userCompanyRepository;
        private readonly IMapper _mapper;

        public PageController(PageRepository pageRepository,
                              UserCompanyRepository userCompanyRepository,
                              HttpContextAccessor acessor,
                              IMapper mapper) : base(acessor)
        {
            _pageRepository = pageRepository;
            _userCompanyRepository = userCompanyRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<PageViewModel>(_pageRepository.GetById(Id)));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<PageViewModel>>(_pageRepository.GetAll()));
        }

        [HttpPost("createpage")]
        public ActionResult Create(PageViewModel page)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage));
            }

            if(!_userCompanyRepository.RepresentCompany(UserId, page.CompanyId))
            {
                return BadRequest(new[] { "This user does not represent the company" });
            }

            page.OwnerId = UserId;
            var pagina = _pageRepository.Add(_mapper.Map<Page>(page));

            if (pagina == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<PageViewModel>(pagina));
        }

        [HttpPut]
        public ActionResult Update(PageViewModel page)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage));
            }

            try
            {
                return Ok(_pageRepository.Update(_mapper.Map<Page>(page)));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}