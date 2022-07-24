using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Application.DTO.Notifications
{
    public class NotificationResult
    {
        public string Content { get; set; }

        public int UserSend { get; set; }

        public int UserReceive { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }
    }
}
