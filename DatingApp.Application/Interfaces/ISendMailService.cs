using DatingApp.Core.Entities;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
