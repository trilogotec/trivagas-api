using Microsoft.AspNetCore.Mvc.Filters;
using System;
using TriVagas.Services.Interfaces;
using TriVagas.WebApi.HttpResults;

namespace TriVagas.WebApi.Filters
{
    public class JWTokenAuthFilter : IAuthorizationFilter
    {
        private readonly IJWTService _jwtService;
        public JWTokenAuthFilter(IJWTService jwtService)
        {
            _jwtService = jwtService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["JWToken"];
            try
            {
                if (!_jwtService.IsTokenValid(token))
                {
                    context.Result = new HttpForbiddenResult();
                    return;
                }
            }
            catch
            {
                context.Result = new HttpForbiddenResult();
                return;
            }
        }
    }
}
