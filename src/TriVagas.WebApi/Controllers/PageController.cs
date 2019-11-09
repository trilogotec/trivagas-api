using Microsoft.AspNetCore.Mvc;
using TriVagas.Services.Requests;

namespace TriVagas.Application.Controllers
{
    [Produces("application/json")]
    [Route("page/")]
    [ApiController]
    public class PageController : ControllerBase
    {
        [HttpPost]
        [Route("createpage")]
        public IActionResult RegistrePage([FromBody] PageRegistreRequest page )
        {
            return Ok(page); 
        }
    }
}

