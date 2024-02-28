using FluentValidation;
using LearningProgramming.Application.Contracts.Identity.Repositories;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.DeleteNavigationMenu
{
    public class DeleteNavigationMenuCommandValidator : AbstractValidator<DeleteNavigationMenuCommand>
    {
        private readonly INavigationMenuRepository _navigationMenuRepository;

        public DeleteNavigationMenuCommandValidator(INavigationMenuRepository navigationMenuRepository)
        {
            _navigationMenuRepository = navigationMenuRepository;
        }
    }
}
