using MediatR;

namespace LearningProgramming.Application.Features.Message.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<Unit>
    {
        public long UserId { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
    }
}
