namespace LearningProgramming.Application.Features.Message.Queries.GetMessages
{
    public class MessageDto
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Unread { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
    }
}
