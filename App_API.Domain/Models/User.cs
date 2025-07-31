using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_API.Domain.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role role { get; set; }

        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    }
    public enum Role
    {
        User,
        Admin
    }
}
