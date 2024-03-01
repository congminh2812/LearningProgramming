using AutoMapper;
using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using MediatR;

namespace LearningProgramming.Application.Features.Role.Commands.CreateRole
{
    public class CreateRoleCommandHandler(IMapper mapper, IRoleRepository roleRepository, IIdentityUnitOfWork identityUnitOfWork) : IRequestHandler<CreateRoleCommand, Unit>
    {
        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<Domain.Role>(request);
            await roleRepository.CreateAsync(model);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
