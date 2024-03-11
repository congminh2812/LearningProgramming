namespace LearningProgramming.Application.Models.Message
{
    public class ChatUserResponse
    {
        public long ReceiverId { get; set; }
        public string FullName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public long SenderId { get; set; }
        public bool Unread { get; set; }
    }
}
