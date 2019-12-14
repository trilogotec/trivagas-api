using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using TriVagas.Services.Interfaces;
using TriVagas.WebApi.HttpResults;

namespace TriVagas.WebApi.Filters
{
  public class JWTokenAuthFilter : IAuthorizationFilter
  {
    private readonly IJWTService _jwtService;
    private readonly IUserService _userService;

    public JWTokenAuthFilter(IJWTService jwtService, IUserService userService)
    {
      _jwtService = jwtService;
      _userService = userService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
      var token = context.HttpContext.Request.Headers["JWToken"];
      try
      {
        if (!_jwtService.IsTokenValid(token))
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
      catch
      {
        context.Result = new HttpForbiddenResult();
        return;
      }
    }
  }
}
