using MusicStreaming.API.DTOs;
using MusicStreaming.API.Entities;

namespace MusicStreaming.API.Interfaces
{
    public interface IPlaylistSongService
    {
        Task<PlaylistSong> AddSongToPlaylistAsync(PlaylistSongDto dto);

        Task<List<PlaylistSong>> GetPlaylistSongsAsync(int playlistId);

        Task<bool> RemoveSongFromPlaylistAsync(int playlistId, int songId);
    }
}