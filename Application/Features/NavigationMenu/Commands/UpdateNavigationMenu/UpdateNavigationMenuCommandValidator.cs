using FluentValidation;
using LearningProgramming.Application.Contracts.Identity.Repositories;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.UpdateNavigationMenu
{
    public class UpdateNavigationMenuCommandValidator : AbstractValidator<UpdateNavigationMenuCommand>
    {
        private readonly INavigationMenuRepository _navigationMenuRepository;

        public UpdateNavigationMenuCommandValidator(INavigationMenuRepository navigationMenuRepository)
        {
            _navigationMenuRepository = navigationMenuRepository;
        }
    }
}
