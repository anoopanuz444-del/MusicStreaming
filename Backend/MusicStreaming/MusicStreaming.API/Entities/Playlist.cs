using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.API.Entities
{
    public class Playlist
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Playlist Name
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Foreign Key -> User
        public int UserId { get; set; }

        // Navigation Property
        public User? User { get; set; }

        // One Playlist -> Many PlaylistSongs
        public ICollection<PlaylistSong>? PlaylistSongs { get; set; }
    }
}