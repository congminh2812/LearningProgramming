namespace LearningProgramming.Application.Features.NavigationMenu.Queries
{
    public class NavigationMenuDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Position { get; set; }
        public List<NavigationMenuDto> Children { get; set; }
    }
}
