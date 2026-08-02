using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.API.DTOs
{
    public class SongDto
    {
        // Song Title
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        // Genre
        [MaxLength(100)]
        public string Genre { get; set; } = string.Empty;

        // Duration in seconds
        public int Duration { get; set; }

        // Release Date
        public DateTime ReleaseDate { get; set; }

        // MP3 File URL
        public string AudioUrl { get; set; } = string.Empty;

        // Cover Image URL
        public string CoverImageUrl { get; set; } = string.Empty;

        // Artist Id
        public int ArtistId { get; set; }
    }
}