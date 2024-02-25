using FluentValidation;
using LearningProgramming.Application.Contracts.Persistence;

namespace LearningProgramming.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateNavigationMenuCommandValidator : AbstractValidator<CreateNavigationMenuCommand>
    {
        private readonly INavigationMenuRepository _navigationMenuRepository;

        public CreateNavigationMenuCommandValidator(INavigationMenuRepository navigationMenuRepository)
        {
            _navigationMenuRepository = navigationMenuRepository;
        }


    }
}
