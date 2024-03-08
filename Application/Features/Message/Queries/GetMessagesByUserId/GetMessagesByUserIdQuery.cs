using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Queries.GetMessagesByUserId
{
    public record GetMessagesByUserIdQuery(long UserId) : IRequest<List<MessageDto>>
    {

    }
}
