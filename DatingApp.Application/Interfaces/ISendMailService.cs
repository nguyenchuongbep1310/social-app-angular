using DatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.Interfaces
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
