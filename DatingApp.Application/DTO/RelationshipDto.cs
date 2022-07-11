using DatingApp.Core.Entities;

namespace DatingApp.Application.DTO
{
    public class RelationshipDto
	{
        public int CurrentUserId { get; set; }
        public int FriendId { get; set; }
        public string Status { get; set; }

        public AppUser CurrentUser { get; set; }
        public AppUser Friend { get; set; }
    }
}

