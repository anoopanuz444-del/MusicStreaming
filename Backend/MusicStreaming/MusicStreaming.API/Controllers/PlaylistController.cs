using Microsoft.AspNetCore.Mvc;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Interfaces;

namespace MusicStreaming.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        // ==========================================================
        // Create Playlist
        // POST: api/Playlist
        // ==========================================================
        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(PlaylistDto dto)
        {
            var playlist = await _playlistService.CreatePlaylistAsync(dto);

            return Ok(playlist);
        }

        // ==========================================================
        // Get All Playlists
        // GET: api/Playlist
        // ==========================================================
        [HttpGet]
        public async Task<IActionResult> GetAllPlaylists()
        {
            var playlists = await _playlistService.GetAllPlaylistsAsync();

            return Ok(playlists);
        }

        // ==========================================================
        // Get Playlist By Id
        // GET: api/Playlist/{id}
        // ==========================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaylistById(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);

            if (playlist == null)
                return NotFound("Playlist not found.");

            return Ok(playlist);
        }

        // ==========================================================
        // Update Playlist
        // PUT: api/Playlist/{id}
        // ==========================================================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlaylist(int id, PlaylistDto dto)
        {
            var playlist = await _playlistService.UpdatePlaylistAsync(id, dto);

            if (playlist == null)
                return NotFound("Playlist not found.");

            return Ok(playlist);
        }

        // ==========================================================
        // Delete Playlist
        // DELETE: api/Playlist/{id}
        // ==========================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var result = await _playlistService.DeletePlaylistAsync(id);

            if (!result)
                return NotFound("Playlist not found.");

            return Ok("Playlist deleted successfully.");
        }
    }
}