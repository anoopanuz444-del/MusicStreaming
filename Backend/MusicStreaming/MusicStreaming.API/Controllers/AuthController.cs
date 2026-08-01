using Microsoft.AspNetCore.Mvc;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Interfaces;

namespace MusicStreaming.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Authentication service
        private readonly IAuthService _authService;

        // Constructor Injection
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ==========================================
        // Register New User
        // POST: /api/Auth/register
        // ==========================================
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                var result = await _authService.RegisterAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }
        }

        // ==========================================
        // Login User
        // POST: /api/Auth/login
        // ==========================================
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var result = await _authService.LoginAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    Message = ex.Message
                });
            }
        }
    }
}