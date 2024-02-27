using AutoMapper;
using LearningProgramming.Application.Contracts.Logging;
using LearningProgramming.Application.Contracts.Persistence;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Queries
{
    public class GetNavigationMenusQueryHandler(INavigationMenuRepository navigationMenuRepository, IAppLogger<GetNavigationMenusQueryHandler> logger, IMapper mapper) : IRequestHandler<GetNavigationMenusQuery, List<NavigationMenuDto>>
    {
        public async Task<List<NavigationMenuDto>> Handle(GetNavigationMenusQuery request, CancellationToken cancellationToken)
        {
            var data = await navigationMenuRepository.GetMenusByUserIdAsync(request.UserId);
            var dataDto = mapper.Map<List<NavigationMenuDto>>(data.Where(x => x.ParentId is null));

            dataDto.ForEach(x =>
            {
                var children = mapper.Map<List<NavigationMenuDto>>(data.Where(d => d.ParentId == x.Id).ToList());
                x.Children = children;
            });

            return dataDto;
        }
    }
}
