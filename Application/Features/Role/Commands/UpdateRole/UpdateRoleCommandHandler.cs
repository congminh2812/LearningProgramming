using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Exceptions;
using MediatR;

namespace LearningProgramming.Application.Features.Role.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler(IRoleRepository roleRepository, IIdentityUnitOfWork identityUnitOfWork) : IRequestHandler<UpdateRoleCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await roleRepository.GetByIdAsync(request.Id)
              ?? throw new NotFoundException(nameof(Domain.Role), request.Id);

            entity.Name = request.Name;
            entity.Description = request.Description;

            roleRepository.Update(entity);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
