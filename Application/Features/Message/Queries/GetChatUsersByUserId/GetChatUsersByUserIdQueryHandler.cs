using AutoMapper;
using LearningProgramming.Application.Contracts.Logging;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using LearningProgramming.Application.Models.Message;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Queries.GetChatUsersByUserId
{
    public class GetChatUsersByUserIdQueryHandler(IMessageRepository messageRepository, IAppLogger<GetChatUsersByUserIdQueryHandler> logger, IMapper mapper) : IRequestHandler<GetChatUsersByUserIdQuery, List<ChatUsersResponse>>
    {
        public async Task<List<ChatUsersResponse>> Handle(GetChatUsersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var data = await messageRepository.GetChatUsersByUserId(request.UserId);

            return data;
        }
    }
}
