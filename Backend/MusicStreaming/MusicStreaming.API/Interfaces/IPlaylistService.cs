using MusicStreaming.API.DTOs;
using MusicStreaming.API.Entities;

namespace MusicStreaming.API.Interfaces
{
    public interface IPlaylistService
    {
        Task<Playlist> CreatePlaylistAsync(PlaylistDto dto);

        Task<List<Playlist>> GetAllPlaylistsAsync();

        Task<Playlist?> GetPlaylistByIdAsync(int id);

        Task<Playlist?> UpdatePlaylistAsync(int id, PlaylistDto dto);

        Task<bool> DeletePlaylistAsync(int id);
    }
}