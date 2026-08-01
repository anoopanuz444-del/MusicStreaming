using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.API.DTOs
{
    public class ArtistDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Bio { get; set; }

        public string? ImageUrl { get; set; }
    }
}