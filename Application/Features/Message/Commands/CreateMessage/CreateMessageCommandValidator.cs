using FluentValidation;
using LearningProgramming.Application.Contracts.Persistence.Repositories;

namespace LearningProgramming.Application.Features.Message.Commands.CreateMessage
{
    public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public CreateMessageCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
    }
}
