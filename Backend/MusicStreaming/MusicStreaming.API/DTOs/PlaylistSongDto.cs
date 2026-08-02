using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.API.DTOs
{
    public class PlaylistSongDto
    {
        [Required]
        public int PlaylistId { get; set; }

        [Required]
        public int SongId { get; set; }
    }
}