using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_API.Domain.IRepository;
using App_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace App_API.Infrastructure.Repository
{
    public class BaseRepoitory<T>:IBaseRepository<T>where T : class
    {
        public readonly AppDbContext _context;
        public BaseRepoitory(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {

            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();

            return entity;

        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
