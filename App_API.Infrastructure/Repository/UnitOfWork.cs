using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_API.Domain.IRepository;
using App_API.Domain.Models;
using App_API.Infrastructure.Data;

namespace App_API.Infrastructure.Repository
{
    public class UnitOfWork:IUnitOfWork
    {


        private readonly AppDbContext _context;

        public IBaseRepository<User> Users { get; private set; }
        public IBaseRepository<Blog> Blogs { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;


            Users = new BaseRepoitory<User>(_context);
            Blogs = new BaseRepoitory<Blog>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
