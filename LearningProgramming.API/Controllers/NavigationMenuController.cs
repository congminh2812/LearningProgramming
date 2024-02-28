using LearningProgramming.Application.Features.NavigationMenu.Commands.CreateNavigationMenu;
using LearningProgramming.Application.Features.NavigationMenu.Commands.DeleteNavigationMenu;
using LearningProgramming.Application.Features.NavigationMenu.Commands.UpdateNavigationMenu;
using LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace LearningProgramming.API.Controllers
{
    public class NavigationMenuController(IMediator mediator) : BaseController
    {
        [HttpGet("getNavigationMenus")]
        public async Task<ActionResult<IEnumerable<NavigationMenuDto>>> GetNavigationMenus()
        {
            var userId = User.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ?? "0";

            var data = await mediator.Send(new GetNavigationMenusQuery(long.Parse(userId)));
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Unit>> Add([FromBody] CreateNavigationMenuCommand request)
        {
            var data = await mediator.Send(request);

            return Ok(data);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Unit>> Update(long id, [FromBody] UpdateNavigationMenuCommand request)
        {
            request.Id = id;
            var data = await mediator.Send(request);

            return Ok(data);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Unit>> Delete(long id)
        {
            var data = await mediator.Send(new DeleteNavigationMenuCommand { Id = id });

            return Ok(data);
        }
    }
}
