using DatingApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        private const string connectionString = @"Data Source=localhost,1433;Database=datingapp; User ID=SA;Password=Chuongbep1310@@";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                base.OnConfiguring(options);
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuider)
        {
            modelBuider.Entity<PostUser>()
                .ToTable("Posts")
                .HasKey(p => p.PostId);

            modelBuider.Entity<AppUser>()
                .ToTable("Users")
                .HasKey(p => p.Id);

            modelBuider.Entity<PostUser>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.Posts)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuider.Entity<UserFriend>()
               .HasKey(k => new { k.SourceUserId, k.TargetUserId });

            modelBuider.Entity<UserFriend>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuider.Entity<UserFriend>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.TargetUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<PostUser> Posts { get; set; }
        public virtual DbSet<UserFriend> Likes { get; set; }
    }
}
