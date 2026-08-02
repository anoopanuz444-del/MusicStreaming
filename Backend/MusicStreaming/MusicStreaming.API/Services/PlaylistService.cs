using Microsoft.EntityFrameworkCore;
using MusicStreaming.API.Data;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Entities;
using MusicStreaming.API.Interfaces;

namespace MusicStreaming.API.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly MusicStreamingDbContext _context;

        public PlaylistService(MusicStreamingDbContext context)
        {
            _context = context;
        }

        // Create Playlist
        public async Task<Playlist> CreatePlaylistAsync(PlaylistDto dto)
        {
            var playlist = new Playlist
            {
                Name = dto.Name,
                UserId = dto.UserId
            };

            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return playlist;
        }

        // Get All Playlists
        public async Task<List<Playlist>> GetAllPlaylistsAsync()
        {
            return await _context.Playlists.ToListAsync();
        }

        // Get Playlist By Id
        public async Task<Playlist?> GetPlaylistByIdAsync(int id)
        {
            return await _context.Playlists.FindAsync(id);
        }

        // Update Playlist
        public async Task<Playlist?> UpdatePlaylistAsync(int id, PlaylistDto dto)
        {
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
                return null;

            playlist.Name = dto.Name;
            playlist.UserId = dto.UserId;

            await _context.SaveChangesAsync();

            return playlist;
        }

        // Delete Playlist
        public async Task<bool> DeletePlaylistAsync(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
                return false;

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}