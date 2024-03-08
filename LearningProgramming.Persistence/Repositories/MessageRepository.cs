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
        public async Task<List<ChatUsersResponse>> GetChatUsersByUserId(long userId)
        {
            var data = await context.Users.Include(x => x.Messages)
                .Where(x => x.Id != userId)
                .Select(x => new ChatUsersResponse
                {
                    UserId = x.Id,
                    FullName = $"{x.FirstName} {x.LastName}",
                    Message = x.Messages.OrderByDescending(x => x.CreatedDate).Select(d => new MessageDto
                    {
                        Content = d.Content,
                        CreatedDate = d.CreatedDate,
                    }).FirstOrDefault(),
                }).ToListAsync();

            return data;
        }
    }
}
