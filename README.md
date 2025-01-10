# Getting Started with the Project in Visual Studio

This guide will help you set up and run the project in Visual Studio. Follow the steps below to get started.

## Prerequisites

Before you begin, make sure you have the following installed:

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) with the following workloads:
  - ASP.NET and web development
  - .NET Core cross-platform development
- [SQL Server](https://www.microsoft.com/en-us/sql-server/) or another supported database
- [Postman](https://www.postman.com/) (optional, for testing the API)

## Steps to Run the Project

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/identityapiendpoints.git
   cd identityapiendpoints
   ```

2. **Open the Solution in Visual Studio**
   - Launch Visual Studio.
   - Click on `File` > `Open` > `Project/Solution`.
   - Navigate to the folder where you cloned the repository and select the `.sln` file.

3. **Configure the Database**
   - Open the `appsettings.json` file.
   - Update the `DefaultConnection` string with your database connection details:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "YourDatabaseConnectionString"
     }
     ```

4. **Apply Migrations**
   - Open the Package Manager Console from `Tools` > `NuGet Package Manager` > `Package Manager Console`.
   - Run the following command to apply the migrations and create the database:
     ```powershell
     Update-Database
     ```

5. **Run the Application**
   - Press `F5` or click the `Start` button to run the project.
   - The application will start, and the API will be available at `https://localhost:5001` (or another specified port).

6. **Test the API**
   - Use Postman or another API testing tool to interact with the endpoints. Refer to the [Authentication Endpoints](#authentication-endpoints) section for a list of available endpoints.

# API Documentation for Endpoints

This document provides a complete list of API endpoints for identity management in ASP.NET Core.

## Authentication Endpoints

### POST /api/auth/register
Registers a new user.
```json
{
  "email": "string",
  "password": "string"
}
```
Response:
```json
{
  "message": "User registered successfully."
}
```

### POST /api/auth/login
Authenticates a user and returns a JWT token.
```json
{
  "email": "string",
  "password": "string"
}
```
Response:
```json
{
  "token": "string",
  "refreshToken": "string"
}
```

### POST /api/auth/refresh
Generates a new JWT token using a refresh token.
```json
{
  "refreshToken": "string"
}
```
Response:
```json
{
  "token": "string",
  "refreshToken": "string"
}
```

### POST /api/auth/forgot-password
Sends a password reset email to the user.
```json
{
  "email": "string"
}
```
Response:
```json
{
  "message": "Password reset email sent."
}
```

### POST /api/auth/reset-password
Resets the user’s password using a token.
```json
{
  "email": "string",
  "token": "string",
  "newPassword": "string"
}
```
Response:
```json
{
  "message": "Password reset successful."
}
```

## User Management Endpoints

### GET /api/profile
Gets details of current user.
Response:
```json
[
  {
    "id": "string",
    "username": "string",
    "email": "string",
...
  }
]
```

### GET /api/profile/{email}
Gets details of a specific user.
Response:
```json
{
  "id": "string",
  "username": "string",
  "email": "string",
...
}
```

## Role Management Endpoints

### POST /api/addRoles
Creates a new role.
```json
{
  "roleName": "string"
}
```
Response:
```json
{
  "message": "Role created successfully."
}
```

### POST /api/user/{userid}/role/{roleid}
Give role to user.
Response:
```json
{
  "message": "Role given successfully."
}
```

### POST /api/user/{userid}/admin
Give admin role to user.
Response:
```json
{
  "message": "Role admin given successfully."
}
```

### POST /api/user/{userid}/user
Give user role to user.
Response:
```json
{
  "message": "Role user given successfully."
}
```




