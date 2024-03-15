using AutoMapper;
using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Commands.CreateMessage
{
    public class CreateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository, IPersistenceUnitOfWork persistenceUnitOfWork) : IRequestHandler<CreateMessageCommand, MessageDto>
    {
        public async Task<MessageDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<Domain.Message>(request);
            model.Unread = true;

            await messageRepository.CreateAsync(model);
            await persistenceUnitOfWork.SaveChangesAsync(cancellationToken);

            var dto = mapper.Map<MessageDto>(model);

            return dto;
        }
    }
}
