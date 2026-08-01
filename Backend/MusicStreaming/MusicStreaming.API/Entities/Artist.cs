using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.API.Entities
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Bio { get; set; }

        public string? ImageUrl { get; set; }
    }
}