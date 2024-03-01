using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Contracts.Identity;
using MediatR;
using LearningProgramming.Application.Exceptions;

namespace LearningProgramming.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(IUserRepository userRepository, IIdentityUnitOfWork identityUnitOfWork) : IRequestHandler<UpdateUserCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await userRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Domain.Role), request.Id);

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Password = request.Password;

            userRepository.Update(entity);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
