using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using MusicStreaming.API.Data;
using MusicStreaming.API.DTOs;
using MusicStreaming.API.Entities;
using MusicStreaming.API.Helpers;      // NEW: Used to generate JWT tokens
using MusicStreaming.API.Interfaces;

namespace MusicStreaming.API.Services
{
    public class AuthService : IAuthService
    {
        // Database context for accessing Users table
        private readonly MusicStreamingDbContext _context;

        // NEW: Helper class responsible for creating JWT tokens
        private readonly JwtHelper _jwtHelper;

        // Constructor Injection
        // ASP.NET Core automatically provides DbContext and JwtHelper
        public AuthService(
            MusicStreamingDbContext context,
            JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        // ============================
        // REGISTER USER
        // ============================
        public async Task<UserResponseDto> RegisterAsync(RegisterDto dto)
        {
            // Check if email already exists
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            // Hash the user's password before storing it
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // Create new User entity
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = passwordHash
            };

            // Save user into SQL Server
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Return user details (never return PasswordHash)
            return new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        // ============================
        // LOGIN USER
        // ============================
        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            // Find the user by email
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == dto.Email);

            // If user doesn't exist
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            // Verify the entered password against the hashed password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

            // Password is incorrect
            if (!isPasswordValid)
            {
                throw new Exception("Invalid password.");
            }

            // NEW:
            // Generate a JWT token after successful login
            string token = _jwtHelper.GenerateToken(user);

            // Return both the JWT token and user details
            return new LoginResponseDto
            {
                Token = token,

                User = new UserResponseDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }
            };
        }
    }
}