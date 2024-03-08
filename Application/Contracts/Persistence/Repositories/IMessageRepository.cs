using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Models.Message;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Persistence.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<List<ChatUsersResponse>> GetChatUsersByUserId(long userId);
    }
}
