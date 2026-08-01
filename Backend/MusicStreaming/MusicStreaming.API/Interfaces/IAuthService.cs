using MusicStreaming.API.DTOs;

namespace MusicStreaming.API.Interfaces
{
    public interface IAuthService
    {
        Task<UserResponseDto> RegisterAsync(RegisterDto dto);

        Task<LoginResponseDto> LoginAsync(LoginDto dto);
    }
}
