using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Entities
{
    public class MailContent
    {
        public string To { get; set; }              // From mail
        public string Subject { get; set; }         // Subject mail
        public string Body { get; set; }            // Content mail
    }
}
