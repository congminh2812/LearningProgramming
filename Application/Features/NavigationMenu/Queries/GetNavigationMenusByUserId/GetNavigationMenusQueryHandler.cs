using AutoMapper;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Contracts.Logging;
using LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenus;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenusByUserId
{
    public class GetNavigationMenusByUserIdQueryHandler(INavigationMenuRepository navigationMenuRepository, IAppLogger<GetNavigationMenusByUserIdQueryHandler> logger, IMapper mapper) : IRequestHandler<GetNavigationMenusByUserIdQuery, List<NavigationMenuDto>>
    {
        public async Task<List<NavigationMenuDto>> Handle(GetNavigationMenusByUserIdQuery request, CancellationToken cancellationToken)
        {
            var data = await navigationMenuRepository.GetMenusByUserIdAsync(request.UserId);
            var dataDto = mapper.Map<List<NavigationMenuDto>>(data.OrderBy(x => x.Position).Where(x => x.ParentId is null));

            dataDto.ForEach(x =>
            {
                var children = mapper.Map<List<NavigationMenuDto>>(data.Where(d => d.ParentId == x.Id).ToList());
                x.Children = children;
            });

            return dataDto;
        }
    }
}
