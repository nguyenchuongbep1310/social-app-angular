using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Entities
{
    public class PostUser : BaseEntity
    {
        public int PostId { get; set; }     
        public string Text { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<PostComment> Comments { get; set; }
        public ICollection<PostLike> Likes { get; set; }
        public int LikesCount { get; set; }

        public int CountLikes()
        {
            return this.Likes.Count();
        }
    }
}
