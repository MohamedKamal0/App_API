using System.Security.Claims;
using App_API.Domain.Dtos;
using App_API.Domain.IRepository;
using App_API.Domain.Models;
using App_API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Blog> _baseRepository;
        public readonly AppDbContext _context;
        public BlogController(IUnitOfWork unitOfWork, IBaseRepository<Blog> baseRepository, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
            _context = context;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlog dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.Users.GetByIdAsync(dto.UserId);
            if (user == null)
                return NotFound(new { message = $"User with ID {dto.UserId} not found." });

            var blog = new Blog
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,
                UserId = dto.UserId
            };

            await _unitOfWork.Blogs.AddAsync(blog);
             _unitOfWork.Complete();

            return CreatedAtAction(nameof(GetBlogById), new { id = blog.Id }, blog);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _unitOfWork.Blogs.GetAllAsync();
            return Ok(new { count = blogs.Count(), data = blogs });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _unitOfWork.Blogs.GetByIdAsync(id);
            if (blog == null)
                return NotFound(new { message = "Blog not found" });

            return Ok(blog);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            int currentUserId = GetUserIdFromToken();

            var user = await _unitOfWork.Users.GetByIdAsync(currentUserId);
            if (user == null || user.role != Role.Admin)
                return Unauthorized(new { message = "Only admins can delete blogs." });

            var blog = await _unitOfWork.Blogs.GetByIdAsync(id);
            if (blog == null)
                return NotFound(new { message = "Blog not found" });
            _context.Blogs.Remove(blog);
            _context.SaveChanges();

            return Ok(new { message = "Blog deleted successfully", blogId = id });
        }

        [HttpGet("user/{userId}/names")]
        public async Task<IActionResult> GetBlogNamesByUser(int userId)
        {
            var blogNames = await _baseRepository.GetBlogNamesByUserIdAsync(userId);
            return Ok(new { userId, blogNames });
        }

        private int GetUserIdFromToken()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    return userId;
                }
            }
            throw new UnauthorizedAccessException("User ID not found in token.");
        }
    }
}
