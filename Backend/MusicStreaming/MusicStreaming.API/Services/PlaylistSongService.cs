using Microsoft.EntityFrameworkCore;
using MusicStreaming.API.Data;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Entities;
using MusicStreaming.API.Interfaces;

namespace MusicStreaming.API.Services
{
    public class PlaylistSongService : IPlaylistSongService
    {
        private readonly MusicStreamingDbContext _context;

        public PlaylistSongService(MusicStreamingDbContext context)
        {
            _context = context;
        }

        // ==========================================================
        // Add Song To Playlist
        // ==========================================================
        public async Task<PlaylistSong> AddSongToPlaylistAsync(PlaylistSongDto dto)
        {
            // Check Playlist Exists
            var playlistExists = await _context.Playlists
                .AnyAsync(p => p.Id == dto.PlaylistId);

            if (!playlistExists)
                throw new Exception("Playlist not found.");

            // Check Song Exists
            var songExists = await _context.Songs
                .AnyAsync(s => s.Id == dto.SongId);

            if (!songExists)
                throw new Exception("Song not found.");

            // Prevent Duplicate Songs
            var alreadyExists = await _context.PlaylistSongs
                .AnyAsync(ps =>
                    ps.PlaylistId == dto.PlaylistId &&
                    ps.SongId == dto.SongId);

            if (alreadyExists)
                throw new Exception("Song already exists in playlist.");

            var playlistSong = new PlaylistSong
            {
                PlaylistId = dto.PlaylistId,
                SongId = dto.SongId
            };

            _context.PlaylistSongs.Add(playlistSong);
            await _context.SaveChangesAsync();

            return playlistSong;
        }

        // ==========================================================
        // Get Songs By Playlist
        // ==========================================================
        public async Task<List<PlaylistSong>> GetPlaylistSongsAsync(int playlistId)
        {
            return await _context.PlaylistSongs
                .Where(ps => ps.PlaylistId == playlistId)
                .Include(ps => ps.Song)
                .ToListAsync();
        }

        // ==========================================================
        // Remove Song From Playlist
        // ==========================================================
        public async Task<bool> RemoveSongFromPlaylistAsync(int playlistId, int songId)
        {
            var playlistSong = await _context.PlaylistSongs
                .FirstOrDefaultAsync(ps =>
                    ps.PlaylistId == playlistId &&
                    ps.SongId == songId);

            if (playlistSong == null)
                return false;

            _context.PlaylistSongs.Remove(playlistSong);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}