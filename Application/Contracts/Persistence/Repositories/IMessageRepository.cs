using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using LearningProgramming.Application.Models.Message;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Persistence.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<List<ChatUserDto>> GetChatUsersByUserId(long userId);
        Task<List<MessageDto>> GetMessagesByUserIdAsync(long userId);
    }
}
