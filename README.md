# 🔥 Blog Management API

A robust and scalable ASP.NET Core Web API built with Clean Architecture principles for managing blogs and users with JWT authentication and PostgreSQL integration.
## ✨ Features

- 🔐 **JWT Authentication & Authorization** - Secure user authentication with role-based access
- 📝 **Blog Management** - Complete CRUD operations for blog posts
- 👥 **User Management** - User registration and profile management
- 🔒 **Role-Based Access Control** - Admin and User roles with different permissions
- 🏗️ **Clean Architecture** - Separation of concerns with proper layering
- 🗃️ **Repository Pattern** - Data access abstraction with Unit of Work
- 🔐 **Password Security** - SHA256 password hashing
- 📚 **Swagger Documentation** - Interactive API documentation
- 🐘 **PostgreSQL Integration** - Robust database with Entity Framework Core

## 🏗️ Architecture

This project implements **Clean Architecture** with four distinct layers:

```
┌─────────────────────────────────────────┐
│             Presentation Layer          │
│              (App_API)                  │
│         Controllers, Middleware         │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│             Application Layer           │
│            (App_API.Service)            │
│           Interfaces, Services          │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│              Domain Layer               │
│             (App_API.Domain)            │
│         Entities, DTOs, Interfaces      │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│           Infrastructure Layer          │
│          (App_API.Infrastructure)       │
│       Data Access, Authentication       │
└─────────────────────────────────────────┘
```

## 🚀 Quick Start

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) 

## 📋 API Endpoints

### 🔐 Authentication

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/api/Auth/register` | Register new user | ❌ |
| `POST` | `/api/Auth/login` | User login & get JWT token | ❌ |

### 📝 Blog Management

| Method | Endpoint | Description | Auth Required | Role |
|--------|----------|-------------|---------------|------|
| `POST` | `/api/Blog/Create` | Create new blog | ❌ | Any |
| `GET` | `/api/Blog/GetAll` | Get all blogs | ❌ | Any |
| `GET` | `/api/Blog/user/{userId}` | Get blog names by user | ❌ | Any |
| `DELETE` | `/api/Blog/Delete?id={id}` | Delete blog | ✅ | Admin |


## 📖 Usage Examples

### User Registration

```bash
curl -X POST "https://localhost:7248/api/Auth/register" \
  -H "Content-Type: application/json" \
  -d '{
    "username": "johndoe",
    "email": "john@example.com",
    "password": "SecurePass123"
  }'
```

### User Login

```bash
curl -X POST "https://localhost:7248/api/Auth/login" \
  -H "Content-Type: application/json" \
  -d '{
    "email": "john@example.com",
    "password": "SecurePass123"
  }'
```

### Create Blog

```bash
curl -X POST "https://localhost:7248/api/Blog/Create" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "My First Blog",
    "description": "This is my first blog about technology",
    "createdAt": "2025-08-01T10:00:00Z",
    "userId": 1
  }'
```

### Delete Blog (Admin Only)

```bash
curl -X DELETE "https://localhost:7248/api/Blog/Delete?id=1" \
  -H "Authorization: Bearer YOUR_JWT_TOKEN_HERE"
```

## 🗂️ Project Structure

```
📁 App_API.sln
├── 📁 App_API/ (Presentation Layer)
│   ├── 📁 Controllers/
│   │   ├── AuthController.cs
│   │   ├── BlogController.cs
│   │   └── WeatherForecastController.cs
│   ├── Program.cs
│   └── appsettings.json
├── 📁 App_API.Domain/ (Domain Layer)
│   ├── 📁 Models/
│   │   ├── User.cs
│   │   ├── Blog.cs
│   │   └── JwtOptions.cs
│   ├── 📁 Dtos/
│   │   ├── LoginRequest.cs
│   │   ├── RegisterRequest.cs
│   │   └── CreateBlog.cs
│   └── 📁 IRepository/
│       ├── IBaseRepository.cs
│       └── IUnitOfWork.cs
├── 📁 App_API.Service/ (Application Layer)
│   └── IAuthService.cs
└── 📁 App_API.Infrastructure/ (Infrastructure Layer)
    ├── 📁 Data/
    │   └── AppDbContext.cs
    ├── 📁 Repository/
    │   ├── BaseRepository.cs
    │   └── UnitOfWork.cs
    ├── 📁 Hashing/
    │   └── PasswordHasher.cs
    ├── 📁 Migrations/
    └── AuthService.cs
```

## 🔒 Security Features

- **JWT Token Authentication** - Stateless authentication
- **Password Hashing** - SHA256 encryption for user passwords
- **Role-Based Authorization** - Admin/User role separation
- **CORS Configuration** - Cross-origin resource sharing
- **Input Validation** - Data annotation validation

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core 8.0
- **Database**: PostgreSQL with Entity Framework Core 9.0.7
- **Authentication**: JWT Bearer Tokens
- **Documentation**: Swagger/OpenAPI
- **Security**: SHA256 Password Hashing
- **Architecture**: Clean Architecture with Repository Pattern


---

**Happy Coding! 🚀**
