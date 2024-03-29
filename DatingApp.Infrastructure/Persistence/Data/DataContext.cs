﻿using DatingApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        private const string connectionString = @"Data Source=localhost,1433;Database=datingapp; User ID=SA;Password=Huy01216903436!";
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
                .WithMany(l => l.FriendUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuider.Entity<UserFriend>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.AddByUsers)
                .HasForeignKey(s => s.TargetUserId)
                .OnDelete(DeleteBehavior.NoAction);

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

            modelBuider.Entity<Notification>()
                .HasKey(n => n.Id);
        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<PostUser> Posts { get; set; }
        public virtual DbSet<PostComment> Comments { get; set; }
        public virtual DbSet<PostLike> Likes { get; set; }
        public virtual DbSet<UserFriend> Friends { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
    }
}
