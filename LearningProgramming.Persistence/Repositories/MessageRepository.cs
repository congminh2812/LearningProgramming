using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using LearningProgramming.Application.Features.Message.Queries.GetMessages;
using LearningProgramming.Application.Models.Message;
using LearningProgramming.Domain;
using LearningProgramming.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Persistence.Repositories
{
    public class MessageRepository(LearningProgrammingAppDbContext context) : Repository<Message, LearningProgrammingAppDbContext>(context), IMessageRepository
    {
        public async Task<List<ChatUserDto>> GetChatUsersByUserId(long userId)
        {
            var data = await context.Users
                .GroupJoin(context.Messages, user => user.Id, message => message.ReceiverId, (user, messages) => new
                {
                    ReceiverId = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    Messages = messages.OrderByDescending(x => x.CreatedAt).AsQueryable()
                })
                .Where(x => x.ReceiverId != userId)
                .Select(x => new ChatUserDto
                {
                    ReceiverId = x.ReceiverId,
                    FullName = x.FullName,
                    Unread = x.Messages.Select(d => d.Unread).FirstOrDefault(),
                    Content = x.Messages.Select(d => d.Content).FirstOrDefault(),
                    CreatedAt = x.Messages.FirstOrDefault() == null ? null : x.Messages.First().CreatedAt,
                }).ToListAsync();

            return data;
        }

        public async Task<List<MessageDto>> GetMessagesByUserIdAsync(long userId)
        {
            var data = await context.Messages
                .Where(x => x.SenderId == userId)
                .Select(x => new MessageDto
                {
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    Unread = x.Unread,
                    ReceiverId = x.ReceiverId,
                    SenderId = x.SenderId,
                })
                .ToListAsync();

            return data;
        }
    }
}
