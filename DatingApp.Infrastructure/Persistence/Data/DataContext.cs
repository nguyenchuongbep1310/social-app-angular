using DatingApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

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

            modelBuider.Entity<PostComment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuider.Entity<PostComment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(s => s.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuider.Entity<PostLike>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(s => s.PostId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<PostUser> Posts { get; set; }
        public virtual DbSet<PostComment> Comments { get; set; }
        public virtual DbSet<PostLike> Likes { get; set; }
    }
}
