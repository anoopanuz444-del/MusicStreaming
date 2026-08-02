using Microsoft.AspNetCore.Mvc;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Interfaces;

namespace MusicStreaming.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        // ==========================================================
        // Get All Songs
        // GET: api/Song
        // ==========================================================
        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await _songService.GetAllSongsAsync();
            return Ok(songs);
        }

        // ==========================================================
        // Get Song By Id
        // GET: api/Song/{id}
        // ==========================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSongById(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);

            if (song == null)
            {
                return NotFound("Song not found.");
            }

            return Ok(song);
        }

        // ==========================================================
        // Create Song
        // POST: api/Song
        // ==========================================================
        [HttpPost]
        public async Task<IActionResult> CreateSong(SongDto dto)
        {
            var song = await _songService.CreateSongAsync(dto);
            return Ok(song);
        }

        // ==========================================================
        // Update Song
        // PUT: api/Song/{id}
        // ==========================================================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong(int id, SongDto dto)
        {
            var song = await _songService.UpdateSongAsync(id, dto);

            if (song == null)
            {
                return NotFound("Song not found.");
            }

            return Ok(song);
        }

        // ==========================================================
        // Delete Song
        // DELETE: api/Song/{id}
        // ==========================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var deleted = await _songService.DeleteSongAsync(id);

            if (!deleted)
            {
                return NotFound("Song not found.");
            }

            return Ok("Song deleted successfully.");
        }
    }
}