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

        public OpportunityController(
            IOpportunityService opportunityService,
            INotify notify) : base(notify)
        {
            _opportunityService = opportunityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var opportunities = await _opportunityService.GetAll();

            return Response(opportunities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var opportunity = await _opportunityService.GetById(id);
            if (opportunity != null)
            {
                return Response(opportunity, 200);
            }
            else
            {
                return Response(code: 404);
            }
        }

        [TypeFilter(typeof(JWTokenAuthFilter))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOpportunityRequest opportunity)
        {
            var createdOpportunity = await _opportunityService.Register(opportunity);

            if (createdOpportunity != null)
            {
                return Response(createdOpportunity, 201);
            }
            else
            {
                return Response(code: 400);
            }
        }

        [TypeFilter(typeof(JWTokenAuthFilter))]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateOpportunityRequest opportunity, int id)
        {
            opportunity.id = id;
            var updatedOpportunity = await _opportunityService.Update(opportunity);

            if (updatedOpportunity != null)
            {
                return Response(updatedOpportunity, 200);
            }
            else
            {
                return Response(code: 400);
            }
        }

        [TypeFilter(typeof(JWTokenAuthFilter))]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            if (await _opportunityService.Remove(id))
            {
                return Response(code: 200);
            }
            else
            {
                return Response(code: 400);
            }
        }
    }
}