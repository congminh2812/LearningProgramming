using LearningProgramming.Application.Extensions;
using LearningProgramming.Application.Features.Role.Commands.CreateRole;
using LearningProgramming.Application.Features.Role.Commands.DeleteRole;
using LearningProgramming.Application.Features.Role.Commands.UpdateRole;
using LearningProgramming.Application.Features.Role.Queries.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningProgramming.API.Controllers
{
    public class RoleController(IMediator mediator) : BaseController
    {
        [HttpGet("getRoles")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var data = await mediator.Send(new GetRolesQuery());
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Unit>> Add([FromBody] CreateRoleCommand request)
        {
            request.CreatedBy = User.GetUserId();
            var data = await mediator.Send(request);

            return Ok(data);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Unit>> Update(long id, [FromBody] UpdateRoleCommand request)
        {
            request.Id = id;
            var data = await mediator.Send(request);

            return Ok(data);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Unit>> Delete(long id)
        {
            var data = await mediator.Send(new DeleteRoleCommand { Id = id });

            return Ok(data);
        }
    }
}
