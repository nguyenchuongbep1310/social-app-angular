namespace DatingApp.Core.Entities
{
    public class PostUser : BaseEntity
    {
        public int PostId { get; set; }     
        public string Text { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
