using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Exceptions;
using MediatR;

namespace LearningProgramming.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler(IUserRepository userRepository, IIdentityUnitOfWork identityUnitOfWork) : IRequestHandler<DeleteUserCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var _ = await userRepository.GetByIdAsync(request.Id)
             ?? throw new BadRequestException($"Id: {request.Id} doesn't exist");

            await userRepository.Delete(request.Id);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
