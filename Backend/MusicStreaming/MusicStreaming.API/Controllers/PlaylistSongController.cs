using Microsoft.AspNetCore.Mvc;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Interfaces;

namespace MusicStreaming.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistSongController : ControllerBase
    {
        private readonly IPlaylistSongService _playlistSongService;

        public PlaylistSongController(IPlaylistSongService playlistSongService)
        {
            _playlistSongService = playlistSongService;
        }

        // Add Song To Playlist
        [HttpPost]
        public async Task<IActionResult> AddSongToPlaylist(PlaylistSongDto dto)
        {
            var result = await _playlistSongService.AddSongToPlaylistAsync(dto);
            return Ok(result);
        }

        // Get Songs In Playlist
        [HttpGet("{playlistId}")]
        public async Task<IActionResult> GetPlaylistSongs(int playlistId)
        {
            var songs = await _playlistSongService.GetPlaylistSongsAsync(playlistId);
            return Ok(songs);
        }

        // Remove Song From Playlist
        [HttpDelete]
        public async Task<IActionResult> RemoveSongFromPlaylist(int playlistId, int songId)
        {
            var removed = await _playlistSongService.RemoveSongFromPlaylistAsync(playlistId, songId);

            if (!removed)
                return NotFound("Song not found in playlist.");

            return Ok("Song removed from playlist successfully.");
        }
    }
}