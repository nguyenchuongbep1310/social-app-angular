using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly DataContext _context;
        public NotificationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Notification> Add(Notification notification)
        {
            _context.Notification.Add(notification);
            await _context.SaveChangesAsync();

            return notification;
        }

        public async Task Delete(int userId)
        {
            var results = _context.Notification.Where(n => n.UserReceive == userId).ToList();
            _context.Notification.RemoveRange(results);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Notification>> GetAll(int userId)
        {
            return await _context.Notification.Where(n => n.UserReceive == userId).ToListAsync();
        }

        public Task<Notification> GetById(int notificationId)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> Update(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
