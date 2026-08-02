using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.API.Entities
{
    public class PlaylistSong
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Foreign Key -> Playlist
        public int PlaylistId { get; set; }

        // Navigation Property
        public Playlist? Playlist { get; set; }

        // Foreign Key -> Song
        public int SongId { get; set; }

        // Navigation Property
        public Song? Song { get; set; }
    }
}