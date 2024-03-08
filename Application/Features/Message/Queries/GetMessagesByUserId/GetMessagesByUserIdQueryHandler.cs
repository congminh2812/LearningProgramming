using AutoMapper;
using LearningProgramming.Application.Contracts.Logging;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Queries.GetMessagesByUserId
{
    public class GetMessagesByUserIdQueryHandler(IMessageRepository messageRepository, IAppLogger<GetMessagesByUserIdQueryHandler> logger, IMapper mapper) : IRequestHandler<GetMessagesByUserIdQuery, List<MessageDto>>
    {
        public async Task<List<MessageDto>> Handle(GetMessagesByUserIdQuery request, CancellationToken cancellationToken)
        {

            return new List<MessageDto>();
        }
    }
}
