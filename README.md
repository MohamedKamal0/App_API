# 🔥 Blog Management API

A robust and scalable **ASP.NET Core Web API** built with **Clean Architecture** principles for managing blogs and users with JWT authentication and PostgreSQL integration.
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
- 🐳 **Docker Support** - Containerized deployment ready

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

### 🐳 Docker Setup (Recommended)

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/blog-management-api.git
   cd blog-management-api
   ```

2. **Run with Docker Compose**
   ```bash
   docker-compose up -d
   ```

3. **Access the API**
   - **API**: `http://localhost:8004`
   - **Swagger UI**: `http://localhost:8004/swagger`
   - **PostgreSQL**: `localhost:8080` (Port 5432 mapped to 8080)

### 🔧 Local Development Setup

1. **Prerequisites**
   - [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
   - [PostgreSQL](https://www.postgresql.org/download/)
   - [Docker](https://www.docker.com/get-started) (optional)

2. **Clone and restore packages**
   ```bash
   git clone https://github.com/yourusername/blog-management-api.git
   cd blog-management-api
   dotnet restore
   ```
## 📋 API Endpoints

### 🔐 Authentication

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `POST` | `/api/Auth/register` | Register new user | ❌ |
| `POST` | `/api/Auth/login` | User login & get JWT token | ❌ |

### 📝 Blog Management

| Method | Endpoint | Description | Auth Required | Role |
|--------|----------|-------------|---------------|------|
| `POST` | `/api/Blog/create` | Create new blog | ❌ | Any |
| `GET` | `/api/Blog/all` | Get all blogs | ❌ | Any |
| `GET` | `/api/Blog/{id}` | Get blog by ID | ❌ | Any |
| `GET` | `/api/Blog/userBlogs?userId={userId}` | Get blog names by user | ❌ | Any |
| `DELETE` | `/api/Blog/delete{id}` | Delete blog | ✅ | Admin |

## 📖 Usage Examples

### User Registration

```bash
curl -X POST "http://localhost:8004/api/Auth/register" \
  -H "Content-Type: application/json" \
  -d '{
    "username": "johndoe",
    "email": "john@example.com",
    "password": "SecurePass123"
  }'
```

### User Login

```bash
curl -X POST "http://localhost:8004/api/Auth/login" \
  -H "Content-Type: application/json" \
  -d '{
    "email": "john@example.com",
    "password": "SecurePass123"
  }'
```

### Create Blog

```bash
curl -X POST "http://localhost:8004/api/Blog/create" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "My First Blog",
    "description": "This is my first blog about technology",
    "createdAt": "2025-08-06T10:00:00Z",
    "userId": 1
  }'
```

### Get All Blogs

```bash
curl -X GET "http://localhost:8004/api/Blog/all"
```

## 🗂️ Project Structure

```
📁 Blog-Management-API/
├── 📁 App_API/ (Presentation Layer)
│   ├── 📁 Controllers/
│   │   ├── AuthController.cs
│   │   ├── BlogController.cs
│   │   └── WeatherForecastController.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── appsettings.Development.json
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
├── 📁 App_API.Infrastructure/ (Infrastructure Layer)
│   ├── 📁 Data/
│   │   └── AppDbContext.cs
│   ├── 📁 Repository/
│   │   ├── BaseRepository.cs
│   │   └── UnitOfWork.cs
│   ├── 📁 Hashing/
│   │   └── PasswordHasher.cs
│   ├── 📁 Migrations/
│   └── AuthService.cs
├── 📄 Dockerfile
├── 📄 docker-compose.yaml
└── 📄 README.md
```

## 🔒 Security Features

- **JWT Token Authentication** - Stateless authentication with configurable lifetime
- **Password Hashing** - SHA256 encryption for user passwords
- **Role-Based Authorization** - Admin/User role separation
- **Input Validation** - Data annotation validation on DTOs
- **CORS Configuration** - Cross-origin resource sharing support
- **HTTPS Support** - SSL/TLS encryption in production

## 🛠️ Technologies Used

| Category | Technology | Version |
|----------|------------|---------|
| **Framework** | ASP.NET Core | 8.0 |
| **Database** | PostgreSQL | 17 |
| **ORM** | Entity Framework Core | 9.0.7 |
| **Authentication** | JWT Bearer Tokens | 8.13.0 |
| **Documentation** | Swagger/OpenAPI | 6.6.2 |
| **Containerization** | Docker | Latest |
| **Architecture** | Clean Architecture | - |
| **Pattern** | Repository + Unit of Work | - |

## 🧪 Testing

### Using Swagger UI
1. Navigate to `http://localhost:8004/swagger`
2. Register a new user
3. Login to get JWT token
4. Click "Authorize" and enter: `Bearer YOUR_TOKEN`
5. Test all endpoints

### Using Postman
Import the provided API collection or use the curl examples above.

### Using curl
All endpoints can be tested using the curl examples provided in the [Usage Examples](#-usage-examples) section.

## 📊 API Response Examples

### Successful Registration Response
```json
"User registered successfully."
```

### Login Response
```json
"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwiZW1haWwiOiJqb2huQGV4YW1wbGUuY29tIiwibmJmIjoxNzMzNTEyMDAwLCJleHAiOjE3MzM1OTg0MDAsImlhdCI6MTczMzUxMjAwMH0.example_signature"
```

### Get All Blogs Response
```json
{
  "count": 2,
  "data": [
    {
      "id": 1,
      "name": "My First Blog",
      "description": "This is my first blog about technology",
      "createdAt": "2025-08-06T10:00:00Z",
      "userId": 1
    },
    {
      "id": 2,
      "name": "Learning ASP.NET Core",
      "description": "A comprehensive guide to ASP.NET Core development",
      "createdAt": "2025-08-06T12:00:00Z",
      "userId": 1
    }
  ]
}
```
