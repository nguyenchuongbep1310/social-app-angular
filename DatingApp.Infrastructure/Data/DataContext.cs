using DatingApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> Users { get; set; }
    }
}
