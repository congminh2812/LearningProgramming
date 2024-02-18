namespace LearningProgramming.Application.Extensions
{
    public static class RegularExpressionManager
    {
        public static string GetEmailRegularExpression()
        {
            // Regular expression for email validation
            return @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        }
    }
}
