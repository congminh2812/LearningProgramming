using LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace LearningProgramming.API.Controllers
{
    public class NavigationMenuController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : BaseController
    {
        [HttpGet("getNavigationMenus")]
        public async Task<ActionResult<IEnumerable<NavigationMenuDto>>> GetNavigationMenus()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? "0";

            var data = await mediator.Send(new GetNavigationMenusQuery(long.Parse(userId)));
            return Ok(data);
        }
    }
}
