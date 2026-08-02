using Microsoft.EntityFrameworkCore;
using MusicStreaming.API.Entities;

namespace MusicStreaming.API.Data
{
    public class MusicStreamingDbContext : DbContext
    {
        public MusicStreamingDbContext(DbContextOptions<MusicStreamingDbContext> options)
            : base(options)
        {
        }

        // User table
        public DbSet<User> Users { get; set; }

        // Artist table (NEW)
        public DbSet<Artist> Artists { get; set; }

        // Songs table (NEW)
        public DbSet<Song> Songs { get; set; }
    }
}