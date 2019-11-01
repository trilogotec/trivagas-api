using System;
using Microsoft.AspNetCore.Mvc;
using TriVagas.Services.Interfaces;

namespace TriVagas.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    [ApiController]
    public class OpportunityController : ControllerBase
    {
        private readonly IOpportunityService _opportunityService;

        public OpportunityController(IOpportunityService opportunityService)
        {
            _opportunityService = opportunityService;
        }

        [HttpGet]
        [Route("opportunity")]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_opportunityService.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}