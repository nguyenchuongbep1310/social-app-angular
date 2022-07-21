using DatingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification> Add(Notification notification);

        Task<Notification> Update(Notification notification);

        Task Delete(int userId);

        Task<Notification> GetById(int notificationId);

        Task<List<Notification>> GetAll(int userId);
    }
}
