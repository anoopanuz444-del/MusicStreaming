using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.API.DTOs
{
    public class PlaylistDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}