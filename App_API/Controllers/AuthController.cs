using App_API.Domain.Dtos;
using App_API.Infrastructure;
using App_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {

            var user = await _authService.RegisterAsync(request);

            return Ok("User registered successfully.");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            var user = await _authService.GetTokenAsync(request);

            var token = (_authService as AuthService)?.GenerateJwtToken(user);
            return Ok(token);
        }

    }
}
