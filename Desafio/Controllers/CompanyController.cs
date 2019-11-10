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
    [Route("api/company")]
    [ApiController]
    [Authorize]
    public class CompanyController : BaseController
    {
        private readonly CompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(CompanyRepository companyRepository,
                                 HttpContextAccessor acessor,
                                 IMapper mapper) : base(acessor)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<CompanyViewModel>(_companyRepository.GetById(Id)));
        }

        [HttpGet]
        public ActionResult GetAll_()
        {
            return Ok(_mapper.Map<IEnumerable<CompanyViewModel>>(_companyRepository.GetAll()));
        }

        [HttpPost]
        public ActionResult Create(CompanyViewModel company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage));
            }

            var companhia = _companyRepository.Add(_mapper.Map<Company>(company));

            if (companhia == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<CompanyViewModel>(companhia));
        }

        [HttpPut]
        public ActionResult Update(CompanyViewModel company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(a => a.Errors).Select(a => a.ErrorMessage));
            }

            try
            {
                return Ok(_companyRepository.Update(_mapper.Map<Company>(company)));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}