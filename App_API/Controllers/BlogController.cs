using System.Security.Claims;
using App_API.Domain.Dtos;
using App_API.Domain.IRepository;
using App_API.Domain.Models;
using App_API.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {


        private readonly IUnitOfWork _unitOfWork;
        public readonly AppDbContext _context;
        private readonly IBaseRepository<Blog> _baseRepository;
        public BlogController(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateBlog([FromBody]CreateBlog  dto)
        {
            var blog = new Blog()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,
           
            };
            await _unitOfWork.Blogs.AddAsync(blog);

            return Ok(blog);
        }

     
        [HttpGet]
        [Route("GetAll")]
        public async Task< IActionResult> GetAllBlog() { 
        
            var blogs= await _unitOfWork.Blogs.GetAllAsync();
            return  Ok( blogs);

        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize]
        public IActionResult DeletBlog(int id )
        {
            int admin = GetUserIdFromToken();
            var role = _context.Users.FirstOrDefault(x => x.UserId == admin)?.role;

            if (Role.Admin != role)
                return Unauthorized(); 
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == id);
            if (blog == null)
                return NotFound(new { message = "Blog not found" });

            _context.Blogs.Remove(blog);
            _context.SaveChanges();

            return Ok(new { message = "Blog deleted successfully", blogId = id });
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
