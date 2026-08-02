using MusicStreaming.API.DTOs;
using MusicStreaming.API.Entities;

namespace MusicStreaming.API.Interfaces
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetAllSongsAsync();

        Task<Song?> GetSongByIdAsync(int id);

        Task<Song> CreateSongAsync(SongDto dto);

        Task<Song?> UpdateSongAsync(int id, SongDto dto);

        Task<bool> DeleteSongAsync(int id);
    }
}