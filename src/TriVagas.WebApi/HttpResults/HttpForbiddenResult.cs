using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TriVagas.WebApi.HttpResults
{
    internal class HttpForbiddenResult : ActionResult
    {
        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            base.ExecuteResult(context);
        }
    }
}
