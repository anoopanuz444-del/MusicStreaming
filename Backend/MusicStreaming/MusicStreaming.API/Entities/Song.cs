using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.API.Entities
{
    public class Song
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Song Name
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        // Song Genre
        [MaxLength(100)]
        public string Genre { get; set; } = string.Empty;

        // Song Duration
        public int Duration { get; set; }

        // Release Date
        public DateTime ReleaseDate { get; set; }

        // MP3 File URL
        public string AudioUrl { get; set; } = string.Empty;

        // Cover Image URL
        public string CoverImageUrl { get; set; } = string.Empty;

        // Foreign Key
        public int ArtistId { get; set; }

        // Navigation Property
        public Artist? Artist { get; set; }
    }
}