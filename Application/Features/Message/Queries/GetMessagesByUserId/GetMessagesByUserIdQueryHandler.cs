using LearningProgramming.Application.Contracts.Persistence.Repositories;
using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Queries.GetMessagesByUserId
{
    public class GetMessagesByUserIdQueryHandler(IMessageRepository messageRepository) : IRequestHandler<GetMessagesByUserIdQuery, List<MessageDto>>
    {
        public async Task<List<MessageDto>> Handle(GetMessagesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var data = await messageRepository.GetMessagesByUserIdAsync(request.UserId);

            return data;
        }
    }
}
