using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Contracts.Identity;
using MediatR;
using LearningProgramming.Application.Exceptions;

namespace LearningProgramming.Application.Features.Role.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler(IRoleRepository roleRepository, IIdentityUnitOfWork identityUnitOfWork) : IRequestHandler<DeleteRoleCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var _ = await roleRepository.GetByIdAsync(request.Id)
               ?? throw new BadRequestException($"Id: {request.Id} doesn't exist");

            await roleRepository.Delete(request.Id);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
