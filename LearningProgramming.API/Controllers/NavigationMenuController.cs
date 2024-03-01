using LearningProgramming.Application.Extensions;
using LearningProgramming.Application.Features.NavigationMenu.Commands.CreateNavigationMenu;
using LearningProgramming.Application.Features.NavigationMenu.Commands.DeleteNavigationMenu;
using LearningProgramming.Application.Features.NavigationMenu.Commands.UpdateNavigationMenu;
using LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenus;
using LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenusByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningProgramming.API.Controllers
{
    public class NavigationMenuController(IMediator mediator) : BaseController
    {
        [HttpGet("getNavigationMenus")]
        public async Task<ActionResult<IEnumerable<NavigationMenuDto>>> GetNavigationMenus()
        {
            var data = await mediator.Send(new GetNavigationMenusQuery());
            return Ok(data);
        }

        [HttpGet("getNavigationMenusByUserId")]
        public async Task<ActionResult<IEnumerable<NavigationMenuDto>>> GetNavigationMenusByUserId()
        {
            var userId = User.GetUserId();
            var data = await mediator.Send(new GetNavigationMenusByUserIdQuery(userId));

            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Unit>> Add([FromBody] CreateNavigationMenuCommand request)
        {
            request.CreatedBy = User.GetUserId();
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
