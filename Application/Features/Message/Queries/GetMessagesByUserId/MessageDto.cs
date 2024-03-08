namespace LearningProgramming.Application.Features.Message.Queries.GetMessages
{
    public class MessageDto
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Unread { get; set; }
    }
}
