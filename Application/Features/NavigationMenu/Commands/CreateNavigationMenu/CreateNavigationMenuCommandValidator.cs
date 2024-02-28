using FluentValidation;
using LearningProgramming.Application.Contracts.Identity.Repositories;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.CreateNavigationMenu
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
