using AutoMapper;
using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Commands.CreateMessage
{
    public class CreateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository, IPersistenceUnitOfWork persistenceUnitOfWork) : IRequestHandler<CreateMessageCommand, Unit>
    {
        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<Domain.Message>(request);
            await messageRepository.CreateAsync(model);
            await persistenceUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
