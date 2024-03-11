using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using LearningProgramming.Application.Models.Message;
using LearningProgramming.Domain;
using LearningProgramming.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LearningProgramming.Persistence.Repositories
{
    public class MessageRepository(LearningProgrammingAppDbContext context) : Repository<Message, LearningProgrammingAppDbContext>(context), IMessageRepository
    {
        public async Task<List<ChatUserResponse>> GetChatUsersByUserId(long userId)
        {
            var data = await context.Users
                .LeftJoin(context.Messages, user => user.Id, message => message.SenderId, (user, message) => new
                {
                    SenderId = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    message.Unread,
                    message.Content,
                    message.CreatedDate,
                    message.ReceiverId,
                })
                .Where(x => x.SenderId != userId)
                .GroupBy(x => new { x.SenderId, x.FullName })
                .Select(x => new ChatUserResponse
                {
                    SenderId = x.Key.SenderId,
                    FullName = x.Key.FullName,
                    Unread = x.OrderByDescending(x => x.CreatedDate).Select(d => d.Unread).FirstOrDefault(),
                    Content = x.OrderByDescending(x => x.CreatedDate).Select(d => d.Content).FirstOrDefault(),
                    CreatedDate = x.OrderByDescending(x => x.CreatedDate).Select(d => d.CreatedDate).FirstOrDefault(),
                    ReceiverId = x.OrderByDescending(x => x.CreatedDate).Select(d => d.ReceiverId).FirstOrDefault(),
                }).ToListAsync();

            return data;
        }
    }
}
