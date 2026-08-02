using Microsoft.EntityFrameworkCore;
using MusicStreaming.API.Data;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Entities;
using MusicStreaming.API.Interfaces;

namespace MusicStreaming.API.Services
{
    public class SongService : ISongService
    {
        private readonly MusicStreamingDbContext _context;

        public SongService(MusicStreamingDbContext context)
        {
            _context = context;
        }

        // ==========================================================
        // Get All Songs
        // ==========================================================
        public async Task<IEnumerable<Song>> GetAllSongsAsync()
        {
            return await _context.Songs.ToListAsync();
        }

        // ==========================================================
        // Get Song By Id
        // ==========================================================
        public async Task<Song?> GetSongByIdAsync(int id)
        {
            return await _context.Songs.FindAsync(id);
        }

        // ==========================================================
        // Create Song
        // ==========================================================
        public async Task<Song> CreateSongAsync(SongDto dto)
        {
            var song = new Song
            {
                Title = dto.Title,
                Genre = dto.Genre,
                Duration = dto.Duration,
                ReleaseDate = dto.ReleaseDate,
                AudioUrl = dto.AudioUrl,
                CoverImageUrl = dto.CoverImageUrl,
                ArtistId = dto.ArtistId
            };

            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return song;
        }

        // ==========================================================
        // Update Song
        // ==========================================================
        public async Task<Song?> UpdateSongAsync(int id, SongDto dto)
        {
            var song = await _context.Songs.FindAsync(id);

            if (song == null)
            {
                return null;
            }

            song.Title = dto.Title;
            song.Genre = dto.Genre;
            song.Duration = dto.Duration;
            song.ReleaseDate = dto.ReleaseDate;
            song.AudioUrl = dto.AudioUrl;
            song.CoverImageUrl = dto.CoverImageUrl;
            song.ArtistId = dto.ArtistId;

            await _context.SaveChangesAsync();

            return song;
        }

        // ==========================================================
        // Delete Song
        // ==========================================================
        public async Task<bool> DeleteSongAsync(int id)
        {
            var song = await _context.Songs.FindAsync(id);

            if (song == null)
            {
                return false;
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}