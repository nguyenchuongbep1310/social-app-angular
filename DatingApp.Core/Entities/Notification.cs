using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int UserSend { get; set; }

        public int UserReceive { get; set; }

        public string Type { get; set; }
    }
}
