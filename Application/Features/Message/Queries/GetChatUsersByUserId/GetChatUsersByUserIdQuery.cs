using LearningProgramming.Application.Models.Message;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Queries.GetChatUsersByUserId
{
    public record GetChatUsersByUserIdQuery(long UserId) : IRequest<List<ChatUserResponse>>
    {
    }
}
