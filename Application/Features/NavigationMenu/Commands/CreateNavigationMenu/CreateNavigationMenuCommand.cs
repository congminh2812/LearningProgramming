﻿using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.CreateNavigationMenu
{
    public class CreateNavigationMenuCommand : IRequest<Unit>
    {
        public long? ParentId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int Position { get; set; }
    }
}
