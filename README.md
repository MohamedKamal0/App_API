# App_API - Blog Management System

A clean architecture ASP.NET Core Web API for managing blogs with JWT authentication and PostgreSQL database integration.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with the following layers:

- **App_API** (Presentation Layer) - Controllers and API endpoints
- **App_API.Service** (Application Layer) - Business logic and interfaces
- **App_API.Domain** (Domain Layer) - Entities, DTOs, and domain interfaces
- **App_API.Infrastructure** (Infrastructure Layer) - Data access, authentication, and external services

## 🚀 Features

- ✅ **User Authentication & Authorization** with JWT tokens
- ✅ **Blog Management** (Create, Read, Delete)
- ✅ **Role-based Access Control** (User/Admin roles)
- ✅ **Repository Pattern** with Unit of Work
- ✅ **Entity Framework Core** with PostgreSQL
- ✅ **Password Hashing** for security
- ✅ **Swagger/OpenAPI** documentation
- ✅ **Clean Architecture** implementation

## 🛠️ Tech Stack

- **Framework**: .NET 8.0
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core 9.0.7
- **Authentication**: JWT Bearer Token
- **Documentation**: Swagger/OpenAPI
- **Architecture**: Clean Architecture

## 📋 Prerequisites

- .NET 8.0 SDK
- PostgreSQL database
- Visual Studio 2022 

 **Run the Application**
```bash
dotnet run --project App_API
```

The API will be available at:
- HTTP: `http://localhost:5261`
- HTTPS: `https://localhost:7248`
- Swagger UI: `https://localhost:7248/swagger`

## 📚 API Endpoints

### Authentication

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/Auth/register` | Register new user | ❌ |
| POST | `/api/Auth/login` | User login | ❌ |

### Blog Management

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/Blog/Create` | Create new blog | ❌ |
| GET | `/api/Blog/GetAll` | Get all blogs | ❌ |
| DELETE | `/api/Blog/Delete?id={id}` | Delete blog (Admin only) | ✅ |

## 🔑 Authentication

The API uses JWT Bearer token authentication. Include the token in the Authorization header:

```
Authorization: Bearer your_jwt_token_here
```

### Sample Requests

**Register User:**
```json
POST /api/Auth/register
{
  "username": "john_doe",
  "email": "john@example.com",
  "password": "securepassword123"
}
```

**Login:**
```json
POST /api/Auth/login
{
  "email": "john@example.com",
  "password": "securepassword123"
}
```

**Create Blog:**
```json
POST /api/Blog/Create
{
  "id": 0,
  "name": "My First Blog",
  "description": "This is my first blog post",
  "createdAt": "2025-07-31T12:00:00Z"
}
```

## 🗂️ Project Structure

```
App_API/
├── App_API/                     # Web API Layer
│   ├── Controllers/
│   ├── Program.cs
│   └── appsettings.json
├── App_API.Domain/              # Domain Layer
│   ├── Models/                  # Entities
│   ├── Dtos/                    # Data Transfer Objects
│   └── IRepository/             # Repository Interfaces
├── App_API.Service/             # Application Layer
│   └── IAuthService.cs
├── App_API.Infrastructure/      # Infrastructure Layer
│   ├── Data/                    # DbContext
│   ├── Repository/              # Repository Implementation
│   ├── Migrations/              # EF Migrations
│   ├── Hashing/                 # Password Hashing
│   └── AuthService.cs           # Authentication Service
└── App_API.sln                  # Solution File
```

## 🔧 Configuration

### JWT Settings
Configure JWT settings in `appsettings.json`:

```json
{
  "JWT": {
    "Issuer": "your_issuer",
    "Audience": "your_audience", 
    "Lifetime": 30,
    "SigningKey": "your_32_character_secret_key_here"
  }
}

---

⭐ If you found this project helpful, please give it a star!
