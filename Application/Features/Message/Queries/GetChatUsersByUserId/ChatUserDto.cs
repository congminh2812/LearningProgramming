namespace LearningProgramming.Application.Models.Message
{
    public class ChatUserDto
    {
        public long ReceiverId { get; set; }
        public string FullName { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool Unread { get; set; }
    }
}
