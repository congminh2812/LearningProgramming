using LearningProgramming.Application.Features.NavigationMenu.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace LearningProgramming.API.Controllers
{
    public class NavigationMenuController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NavigationMenuController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IEnumerable<NavigationMenuDto>> Get()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? "0";

            var leaveTypes = await _mediator.Send(new GetNavigationMenusQuery(long.Parse(userId)));
            return leaveTypes;
        }
    }
}
