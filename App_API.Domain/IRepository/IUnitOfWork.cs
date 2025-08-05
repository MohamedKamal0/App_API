using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using App_API.Domain.Models;

namespace App_API.Domain.IRepository
{
    public interface IUnitOfWork:IDisposable
    {

        IBaseRepository<User> Users { get; }
        IBaseRepository<Blog> Blogs { get; }
        int Complete();
        
    }
}
