# SECCL Integration – Technical Task

This project demonstrates the integration of the SECCL API with a decoupled .NET Core backend, Blazor WebAssembly frontend, and a middleware service for portfolio data manipulation.

---

## 🔧 Tech Stack

- **.NET 8** – Backend (Minimal API)
- **Blazor WebAssembly** – Frontend UI
- **C# Class Library** – Middleware (data aggregation)
- **SECCL API** – External API for client portfolio data
- **Visual Studio 2022/2023**

---

## ⚙️ Folder Structure

SecclIntegration/
│
├── Seccl.Api/ # Minimal API project
│ └── Services/
│ ├── SecclAuthService.cs
│ └── PortfolioService.cs
│ └── Program.cs
│
├── Seccl.Middleware/ # Middleware project (business logic)
│ └── Models/
│ └── PortfolioBalance.cs
│ └── Services/
│ └── PortfolioAggregator.cs
│
├── Seccl.Client/ # Blazor WebAssembly frontend
│ └── Pages/
│ └── Dashboard.razor
│ └── Program.cs
│└── README.md

Step 2: Start the API
bash
Copy
Edit
cd Seccl.Api
dotnet run
Step 3: Start the Blazor Frontend
bash
Copy
Edit
cd Seccl.Client
dotnet run
Make sure both API and Client apps are running on different ports.

🌐 API Endpoints
Endpoint	Description
/api/portfolio/total	Returns total value from 3 portfolios
/api/portfolio/by-type	Returns grouped balances by account type

🖥️ Frontend Dashboard
Shows Total Portfolio Value

Lists balances grouped by Account Type (ISA, GIA, SIPP, etc.)

Built using Blazor WebAssembly and calls the backend API via HttpClient

