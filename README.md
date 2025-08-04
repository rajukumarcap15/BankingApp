# 🏦 Banking System RESTful API

## 📖 Overview

This project is a RESTful API developed using **ASP.NET Core (.NET 8)** for managing customer bank accounts. It follows **Clean Architecture** principles and implements the **CQRS** design pattern using **MediatR**. The API supports operations to retrieve and update bank account details based on account type or unique identifier.

---

## 🚀 Features

- 🔍 **Retrieve Bank Accounts by Type**
  - Endpoint to get all bank accounts of a specified type (`savings` or `current`).

- 🔎 **Retrieve Specific Bank Account**
  - Endpoint to fetch details of a specific bank account using its unique ID.

- ✏️ **Update Specific Bank Account**
  - Endpoint to update details of a specific bank account using its unique ID.

---

## 🧱 Architecture

- **Clean Architecture** with separation of concerns:
  - `Domain` – Core business models and interfaces
  - `Application` – CQRS handlers, DTOs, and MediatR requests
  - `Infrastructure` – Mock data and services
  - `API` – Controllers and dependency injection

- **CQRS Pattern**:
  - Commands for write operations
  - Queries for read operations

- **MediatR Integration**:
  - Decouples request handling using `IMediator`

---

## 🧪 Testing

- ✅ Unit tests written using **xUnit**
- 🧪 Tests cover:
  - Application layer (handlers)
  - Domain logic
  - API controllers (via mock services)

---

## 🛠️ Technologies Used

| Technology       | Purpose                          |
|------------------|----------------------------------|
| .NET 8           | Framework                        |
| ASP.NET Core     | Web API                          |
| MediatR          | CQRS and request handling        |
| xUnit            | Unit testing                     |
| Moq              | Mocking dependencies             |

---

## 📦 Setup Instructions

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022+ or VS Code

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/banking-api.git
   cd banking-api
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the API**:
   ```bash
   dotnet run --project src/Banking.API
   ```

4. **Run tests**:
   ```bash
   dotnet test
   ```

---

## 📂 Project Structure

```
Banking.API/
├── src/
│   ├── Banking.API/           # API layer (Controllers, DI)
│   ├── Banking.Application/   # CQRS Handlers, DTOs, MediatR
│   ├── Banking.Domain/        # Entities, Interfaces
│   ├── Banking.Infrastructure/# Mock data and services
├── tests/
│   ├── Banking.Tests/         # xUnit test projects
```

---

## 📄 License

This project is licensed under the **MIT License**.

---

## 👤 Author

Developed by [Raju Kumar](https://github.com/rajukumarcap15)
