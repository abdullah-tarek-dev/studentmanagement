# Student Management System

## Overview

This is a web application built with **ASP.NET Core MVC** and **PostgreSQL** that helps manage student records efficiently.  
Users can register, log in, and perform CRUD operations on students and departments.

---

## Features

- User Registration and Login with password hashing (SHA256)  
- Manage Students (Add, Edit, Delete)  
- Manage Departments  
- Session-based Authentication  
- Responsive UI with Bootstrap

---

## Technologies Used

- ASP.NET Core MVC  
- Entity Framework Core (EF Core)  
- PostgreSQL  
- Bootstrap (for styling)  
- SHA256 Password Hashing

---

## Getting Started

### Prerequisites

- [.NET 8 SDK or later](https://dotnet.microsoft.com/download)  
- [PostgreSQL](https://www.postgresql.org/download/) installed and running  
- An IDE or code editor (Visual Studio / VS Code)

### Setup

1. Clone the repository:  
   ```bash
   git clone https://github.com/abdullah-tarek-dev/studentmanagement.git
   cd studentmanagement
Update the PostgreSQL connection string in appsettings.json or directly in PostgresContext.cs (for development):

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123456"
}
Run database migrations or scaffold database (if needed).

Run the application:

dotnet run
Open your browser and navigate to https://localhost:5001 or http://localhost:5000.

Notes
Passwords are stored securely using SHA256 hashing.

Sessions are used to maintain logged-in state.

This project is under active development, contributions and feedback are welcome!

