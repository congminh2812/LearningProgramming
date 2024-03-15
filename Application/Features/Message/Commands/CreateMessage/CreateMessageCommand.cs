using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<MessageDto>
    {
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public string Content { get; set; }
    }
}
