using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_API.Domain.Dtos;
using App_API.Domain.Models;

namespace App_API.Service
{
    public interface IAuthService
    {

        Task<User> RegisterAsync(RegisterRequest model);
        Task<User> GetTokenAsync(LoginRequest model);
    }
}
