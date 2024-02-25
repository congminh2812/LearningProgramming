
using LearningProgramming.Application.Models.Email;

namespace LearningProgramming.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
