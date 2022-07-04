using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Entities
{
    public class Relationships
    {
        public int Id { get; set; }
        public int CurrentUserId { get; set; }
        public int FriendId { get; set; }
        public string status { get; set; }

        public AppUser CurrentUser { get; set; }
        public AppUser Friend { get; set; }
    }
}
