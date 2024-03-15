using LearningProgramming.Application.Extensions;
using LearningProgramming.Application.Features.Message.Commands.CreateMessage;
using LearningProgramming.Application.Features.Message.Commands.UpdateUnreadMessage;
using LearningProgramming.Application.Features.Message.Queries.GetChatUsersByUserId;
using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using LearningProgramming.Application.Features.Message.Queries.GetMessagesByUserId;
using LearningProgramming.Application.Models.Message;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearningProgramming.API.Controllers
{
    public class MessageController(IMediator mediator) : BaseController
    {
        [HttpGet("getChatUsersByUserId")]
        public async Task<ActionResult<IEnumerable<ChatUserDto>>> GetChatUsersByUserId()
        {
            var userId = User.GetUserId();
            var data = await mediator.Send(new GetChatUsersByUserIdQuery(userId));

            return Ok(data);
        }

        [HttpGet("getMessagesByUserId")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesByUserId()
        {
            var userId = User.GetUserId();
            var data = await mediator.Send(new GetMessagesByUserIdQuery(userId));

            return Ok(data);
        }

        [HttpPut("updateUnreadMessage/{messageId}")]
        public async Task<ActionResult<Unit>> UpdateUnreadMessage(long messageId)
        {
            var data = await mediator.Send(new UpdateUnreadMessageCommand(messageId));

            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Unit>> Add([FromBody] CreateMessageCommand request)
        {
            request.SenderId = User.GetUserId();
            var data = await mediator.Send(request);

            return Ok(data);
        }
    }
}
