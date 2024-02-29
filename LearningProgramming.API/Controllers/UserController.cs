using LearningProgramming.Application.Features.User.Commands.CreateUser;
using LearningProgramming.Application.Features.User.Commands.DeleteUser;
using LearningProgramming.Application.Features.User.Commands.UpdateUser;
using LearningProgramming.Application.Features.User.Queries.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningProgramming.API.Controllers
{
    public class UserController(IMediator mediator) : BaseController
    {
        [HttpGet("getUsers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var data = await mediator.Send(new GetUsersQuery());
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Unit>> Add([FromBody] CreateUserCommand request)
        {
            var data = await mediator.Send(request);

            return Ok(data);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Unit>> Update(long id, [FromBody] UpdateUserCommand request)
        {
            request.Id = id;
            var data = await mediator.Send(request);

            return Ok(data);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Unit>> Delete(long id)
        {
            var data = await mediator.Send(new DeleteUserCommand { Id = id });

            return Ok(data);
        }
    }
}
