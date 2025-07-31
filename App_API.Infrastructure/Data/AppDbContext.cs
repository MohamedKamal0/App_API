using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace App_API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
        .HasOne(b => b.User)
        .WithMany(b=>b.Blogs)
        .HasForeignKey(b => b.UserId);
        }
    }
}
