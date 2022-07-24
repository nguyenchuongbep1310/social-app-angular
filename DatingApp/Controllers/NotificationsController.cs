using DatingApp.Application.DTO.Notifications;
using DatingApp.Core.Entities;
using DatingApp.Core.Extension;
using DatingApp.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public NotificationsController(INotificationRepository notificationRepository, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _notificationRepository = notificationRepository;
            _hubContext = hubContext;
        }

        [Route("notificationcount")]
        [HttpGet]
        public async Task<ActionResult<NotificationCountResult>> GetNotificationCount(int userId) //userId is Id of User that receive notification
        {
            var notifications = await _notificationRepository.GetAll(userId);
            var count = notifications.Count();

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
            var results = _notificationRepository.GetAll(userId).Result.OrderByDescending(n => n.Id).Select(n => new NotificationResult()
            {
                Content = n.Content,
                Type = n.Type,
                UserSend = n.UserSend,
                UserReceive = n.UserReceive,
                Status = n.Status,
            }).ToList();

            return results;
        }

        // DELETE: api/Notifications/deletenotifications
        [Authorize]
        [HttpDelete]
        [Route("deletenotifications")]
        public async Task<IActionResult> DeleteNotifications(int userId)
        {
            int currentLoginUserId = User.GetUserId();
            if (currentLoginUserId != userId) return BadRequest("You do not have permisson to do this action.");

            await _notificationRepository.Delete(userId);

            return NoContent();
        }

        [Authorize]
        [HttpPatch]
        [Route("updatenotification")]
        public async Task<IActionResult> UpdateNotificationStatus(int notificationUpdatedId)
        {
            var notificationUpdated = await _notificationRepository.GetById(notificationUpdatedId);
            int currentLoginUserId = User.GetUserId();
            if (currentLoginUserId != notificationUpdated.UserReceive) return BadRequest("You do not have permisson to do this action.");

            notificationUpdated.Status = "Seen";
            await _notificationRepository.Update(notificationUpdated);

            return Ok(notificationUpdated);   
        }
    }
}
