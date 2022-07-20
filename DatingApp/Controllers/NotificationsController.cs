using DatingApp.Application.DTO.Notifications;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public NotificationsController(DataContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [Route("notificationcount")]
        [HttpGet]
        public ActionResult<NotificationCountResult> GetNotificationCount(int userId) //userId is Id of User that receive notification
        {
            //var count = (from not in _context.Notification
            //             select not).CountAsync();

            var count = _context.Notification.Where(n => n.Id == userId).Count();

            NotificationCountResult result = new NotificationCountResult
            {
                Count = count
            };
            return result;
        }

        [Route("notificationresult")]
        [HttpGet]
        public ActionResult<List<NotificationResult>> GetNotificationMessage(int userId) //userId is Id of User that receive notification
        {
            //var results = from message in _context.Notification
            //              orderby message.Id descending
            //              select new NotificationResult
            //              {
            //                  EmployeeName = message.EmployeeName,
            //                  TranType = message.TranType
            //              };

            var results = _context.Notification.Where(n => n.Id == userId).OrderByDescending(n => n.Id).Select(n => new NotificationResult()
            {
                Content = n.Content,
                Type = n.Type,
                UserSend = n.UserSend,
                UserReceive = n.UserReceive,
            }).ToList();

            return results;
        }

        // DELETE: api/Notifications/deletenotifications
        [HttpDelete]
        [Route("deletenotifications")]
        public async Task<IActionResult> DeleteNotifications(int userId)
        {
            var results = _context.Notification.Where(n => n.UserReceive == userId).ToList();
            _context.Notification.RemoveRange(results);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
