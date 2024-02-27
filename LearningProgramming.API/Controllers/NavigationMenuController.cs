using LearningProgramming.Application.Features.NavigationMenu.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace LearningProgramming.API.Controllers
{
    public class NavigationMenuController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : BaseController
    {
        [HttpGet("getNavigationMenus")]
        public async Task<IEnumerable<NavigationMenuDto>> GetNavigationMenus()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? "0";

            var leaveTypes = await mediator.Send(new GetNavigationMenusQuery(long.Parse(userId)));
            return leaveTypes;
        }
    }
}
