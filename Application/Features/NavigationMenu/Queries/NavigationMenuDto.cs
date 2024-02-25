namespace LearningProgramming.Application.Features.NavigationMenu.Queries
{
    public class NavigationMenuDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int Position { get; set; }
        public NavigationMenuDto ParentNavigationMenu { get; set; }
    }
}
