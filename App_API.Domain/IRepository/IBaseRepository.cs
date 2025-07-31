using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_API.Domain.Models;

namespace App_API.Domain.IRepository
{
    public interface IBaseRepository<T>where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task SaveAsync();
        Task<IEnumerable<string>> GetBlogNamesByUserIdAsync(int userId);

    }
}
