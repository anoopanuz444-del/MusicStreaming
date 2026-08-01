using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStreaming.API.Data;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Entities;

namespace MusicStreaming.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly MusicStreamingDbContext _context;

        public ArtistController(MusicStreamingDbContext context)
        {
            _context = context;
        }

        // ==========================================================
        // Create Artist
        // POST: api/Artist
        // ==========================================================
        [HttpPost]
        public async Task<IActionResult> CreateArtist(ArtistDto dto)
        {
            var artist = new Artist
            {
                Name = dto.Name,
                Bio = dto.Bio,
                ImageUrl = dto.ImageUrl
            };

            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            return Ok(artist);
        }
        // ==========================================================
        // Get All Artists
        // GET: api/Artist
        // ==========================================================
        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            var artists = await _context.Artists.ToListAsync();

            return Ok(artists);
        }
        // ==========================================================
        // Get Artist By Id
        // GET: api/Artist/{id}
        // ==========================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistById(int id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound("Artist not found.");
            }

            return Ok(artist);
        }
        // ==========================================================
        // Update Artist
        // PUT: api/Artist/{id}
        // ==========================================================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, ArtistDto dto)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound("Artist not found.");
            }

            // Update values
            artist.Name = dto.Name;
            artist.Bio = dto.Bio;
            artist.ImageUrl = dto.ImageUrl;

            await _context.SaveChangesAsync();

            return Ok(artist);
        }
        // ==========================================================
        // Delete Artist
        // DELETE: api/Artist/{id}
        // ==========================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            // Find artist by ID
            var artist = await _context.Artists.FindAsync(id);

            // Check if artist exists
            if (artist == null)
            {
                return NotFound("Artist not found.");
            }

            // Remove artist from database
            _context.Artists.Remove(artist);

            // Save changes
            await _context.SaveChangesAsync();

            return Ok("Artist deleted successfully.");
        }




    }

}