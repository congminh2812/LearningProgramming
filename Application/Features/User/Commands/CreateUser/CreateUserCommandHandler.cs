using AutoMapper;
using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Exceptions;
using MediatR;

namespace LearningProgramming.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository, IIdentityUnitOfWork identityUnitOfWork, IMapper mapper) : IRequestHandler<CreateUserCommand, Unit>
    {
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await userRepository.FindByEmailAsync(request.Email);

            if (entity is not null)
                throw new BadRequestException($"Email: {request.Email} existed");

            var model = mapper.Map<Domain.User>(request);
            await userRepository.CreateAsync(model);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
