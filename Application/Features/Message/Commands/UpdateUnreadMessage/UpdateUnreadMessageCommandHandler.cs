using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using MediatR;

namespace LearningProgramming.Application.Features.Message.Commands.UpdateUnreadMessage
{
    public class UpdateUnreadMessageCommandHandler(IMessageRepository messageRepository, IPersistenceUnitOfWork persistenceUnitOfWork) : IRequestHandler<UpdateUnreadMessageCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateUnreadMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await messageRepository.GetByIdAsync(request.MessageId);
            message.Unread = false;

            await messageRepository.CreateAsync(message);
            await persistenceUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
