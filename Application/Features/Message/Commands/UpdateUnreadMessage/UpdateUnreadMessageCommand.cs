using MediatR;

namespace LearningProgramming.Application.Features.Message.Commands.UpdateUnreadMessage
{
    public record UpdateUnreadMessageCommand(long MessageId) : IRequest<Unit>
    {
    }
}
