# Gym Management System

A comprehensive web-based management system for gym operations built with ASP.NET Core MVC. The application streamlines member management, trainer administration, training sessions, memberships, and health records.

## 📋 Project Overview

The Gym Management System is designed to provide gym administrators with tools to:
- Manage gym members with health records and membership tracking
- Administer trainers and their specialties
- Schedule and manage training sessions
- Create and manage membership plans
- Book members into sessions
- Track member health metrics (blood type, address, etc.)

### Key Features
- **Member Management**: Create, read, update, delete (CRUD) operations for gym members
- **Trainer Management**: Manage trainer profiles and specialties
- **Session Scheduling**: Create and manage training sessions with category-based organization
- **Membership Plans**: Define and track different membership packages
- **Health Records**: Track member health information including blood type
- **Session Bookings**: Allow members to book training sessions
- **Role-Based Access**: ASP.NET Core Identity integration for user authentication and authorization

## 🛠 Technology Stack

### Backend Framework
- **ASP.NET Core 9.0** - Modern, high-performance framework for building web applications

### Architecture & Patterns
- **MVC (Model-View-Controller)** - UI layer with views, controllers, and models
- **Repository Pattern** - Generic repository for data access abstraction
- **Unit of Work Pattern** - Transaction management across multiple repositories
- **Dependency Injection** - Built-in IoC container for loose coupling

### Database & ORM
- **Entity Framework Core 9.0.9** - Code-first ORM for database operations
- **SQL Server** - Primary database system
- **Fluent API & Configuration** - Entity mapping and relationships

### Authentication & Authorization
- **ASP.NET Core Identity** - User authentication and role-based authorization
- **Identity EntityFrameworkCore 9.0.10** - Identity integration with EF Core

### Mapping & Utilities
- **AutoMapper 15.0.1** - DTO and view model mapping

### Frontend
- **Razor Views** - Server-side view rendering with C#
- **Bootstrap 5** - Responsive UI framework
- **jQuery** - Client-side interactivity
- **HTML5/CSS3** - Markup and styling

## 📁 Project Structure

```
GymManagementSystemSolution/
├── GymManagement/                    # Presentation Layer (ASP.NET Core MVC)
│   ├── Controllers/                  # MVC Controllers
│   │   ├── HomeController.cs
│   │   ├── MemberController.cs
│   │   ├── TrainerController.cs
│   │   ├── SessionController.cs
│   │   └── PlanController.cs
│   ├── Models/                       # View Models & Error Models
│   ├── Views/                        # Razor View Templates
│   │   ├── Member/
│   │   ├── Trainer/
│   │   ├── Session/
│   │   ├── Plan/
│   │   ├── Home/
│   │   └── Shared/
│   ├── wwwroot/                      # Static Files (CSS, JS, Images)
│   ├── Program.cs                    # Application Entry Point & DI Configuration
│   ├── appsettings.json              # Configuration Settings
│   └── GymManagement.csproj
│
├── GymDataAccess/                    # Data Access Layer (Repository Pattern)
│   ├── Models/                       # Domain Entities
│   │   ├── Member.cs
│   │   ├── Trainer.cs
│   │   ├── Sessions.cs
│   │   ├── Plan.cs
│   │   ├── Category.cs
│   │   ├── MemberShip.cs
│   │   ├── HealthRecord.cs
│   │   ├── Address.cs
│   │   ├── MembersBookingSessions.cs
│   │   ├── ApplicationUser.cs
│   │   └── Enums/                   # Enumerations (Gender, Specialties)
│   ├── Data/
│   │   ├── DbContext/               # EF Core DbContext
│   │   ├── Configurations/          # Fluent API Entity Mapping
│   │   ├── Migrations/              # Database Migration History
│   │   └── SeedData/                # Data Seeding for Initial Setup
│   ├── Repositories/
│   │   ├── Interfaces/
│   │   │   ├── IUnitOfWork.cs
│   │   │   ├── IRepositoryGeneric.cs
│   │   │   └── ISessionRepository.cs
│   │   └── Classes/
│   │       ├── UnitOfWork.cs
│   │       ├── GenericRepository.cs
│   │       └── SessionRepository.cs
│   └── GymDataAccess.csproj
│
└── GymBusinessLogic/                 # Business Logic Layer
    ├── Services/
    │   ├── Interfaces/
    │   │   ├── IMemberService.cs
    │   │   ├── ITrainerService.cs
    │   │   ├── ISessionService.cs
    │   │   └── IPlanService.cs
    │   └── Classes/
    │       ├── MemberServices.cs
    │       ├── TrainerServices.cs
    │       ├── SessionService.cs
    │       └── PlanService.cs
    ├── ViewModels/
    │   ├── MemberViewModel/
    │   ├── TrainerViewModel/
    │   ├── SessionViewModels/
    │   └── PlanViewModel/
    ├── MappingProfiles.cs            # AutoMapper Configuration
    └── GymBusinessLogic.csproj
```

## 🔧 Installation & Setup

### Prerequisites
- **.NET 9.0 SDK** or later ([Download](https://dotnet.microsoft.com/download))
- **SQL Server** (LocalDB, Express, or Full Edition)
- **Visual Studio 2022** or **Visual Studio Code** with C# extension (recommended)

### Clone the Repository
```bash
git clone https://github.com/Sa-Hesham/GymManagementSystem.git
cd GymManagementSystem
```

### Configuration

#### 1. Database Connection String
Update `GymManagement/appsettings.json` with your SQL Server configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=GymSystem;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Connection String Explanation:**
- `Server=.` - Connect to local SQL Server (`.` represents localhost)
- `Database=GymSystem` - Database name
- `Trusted_Connection=True` - Use Windows authentication
- `TrustServerCertificate=True` - Trust self-signed certificates

**Alternative Connection String (SQL Server with username/password):**
```json
"DefaultConnection": "Server=YOUR_SERVER;Database=GymSystem;User Id=sa;Password=YourPassword;TrustServerCertificate=True"
```

#### 2. Install Dependencies
```bash
dotnet restore
```

#### 3. Apply Migrations & Create Database
```bash
cd GymManagement
dotnet ef database update --project ../GymDataAccess
```

This command will:
- Create the database `GymSystem` in SQL Server
- Apply all migrations
- Seed initial data (roles, users, and gym data)

## 🚀 Running the Application

### Visual Studio
1. Set `GymManagement` as the startup project
2. Press `F5` or click **Start Debugging**
3. The application will launch at `https://localhost:7000` (or your configured port)

### Command Line
```bash
cd GymManagement
dotnet run
```

The application will start at `https://localhost:5001` by default.

### Application Access
- **URL**: `https://localhost:7000` (or configured HTTPS port)
- **Home Page**: Dashboard overview
- **Navigation**: Use the top menu to access different modules

## 📖 Usage Guide

### User Roles
The system supports role-based access control (configured during seeding):

#### Available Roles
- **Admin** - Full access to all features
- **Manager** - Management of members, trainers, and sessions
- **Trainer** - View assigned sessions and members
- **Member** - View personal bookings and health records

### Core Modules

#### 1. Member Management
- **Navigation**: Members → List
- **Actions**:
  - Create new member
  - View member details and health records
  - Update member information
  - Delete member record
  - Book member into sessions

#### 2. Trainer Management
- **Navigation**: Trainers → List
- **Actions**:
  - Create new trainer with specialty
  - View trainer profile
  - Edit trainer information
  - Delete trainer

#### 3. Session Management
- **Navigation**: Sessions → List
- **Actions**:
  - Create training sessions (select trainer and category)
  - View session details and attendees
  - Edit session schedule
  - Delete session
  - Book members into sessions

#### 4. Membership Plans
- **Navigation**: Plans → List
- **Actions**:
  - Create membership plans
  - View plan details
  - Update plan information
  - Delete plan

#### 5. Health Records
- **Member Details** → Health Record section
- View member's blood type and health information

### Workflow Example

**Typical Member Onboarding:**
1. Navigate to Members → Create New
2. Fill in member details (name, gender, address, etc.)
3. Set blood type in health record section
4. Assign membership plan
5. Navigate to Sessions and book member into available sessions

## 🔐 Authentication & Authorization

### First-Time Login
The system seeds default users and roles. Check the seeding configuration files:
- `GymDataAccess/Data/SeedData/IDentityDataSeeding.cs` - Identity setup
- `GymDataAccess/Data/SeedData/GymDataSeeding.cs` - Domain data setup

### Default Credentials
Refer to the seeding implementation for initial user credentials.

### User Registration
New users can be registered through ASP.NET Core Identity integration.

## 📊 Database Schema

### Key Entities
- **Member** - Gym members with personal information
- **Trainer** - Training staff with specialties
- **Sessions** - Training classes scheduled by trainer and category
- **Plan** - Membership packages
- **MemberShip** - Member subscription to plans
- **HealthRecord** - Member health metrics
- **Category** - Training session categories
- **Address** - Member addresses
- **MembersBookingSessions** - Junction table for session bookings
- **ApplicationUser** - Extended Identity user

### Relationships
- Member 1:N Sessions (through MembersBookingSessions)
- Trainer 1:N Sessions
- Plan 1:N Membership
- Category 1:N Sessions

## 🛠 Development

### Project Dependencies

**GymManagement (Presentation Layer)**
- ASP.NET Core MVC (built-in)
- References: GymBusinessLogic, GymDataAccess

**GymBusinessLogic (Business Logic Layer)**
- AutoMapper 15.0.1
- References: GymDataAccess

**GymDataAccess (Data Access Layer)**
- Microsoft.EntityFrameworkCore.SqlServer 9.0.9
- Microsoft.AspNetCore.Identity.EntityFrameworkCore 9.0.10

### Building the Solution
```bash
dotnet build
```

### Running Tests
Currently, the solution does not include a test project. Consider adding xUnit or NUnit for unit testing.

### Adding New Features

**Example: Add a new entity**
1. Create model class in `GymDataAccess/Models/`
2. Add DbSet property to `GymDbContext`
3. Create Fluent API configuration in `GymDataAccess/Data/Configurations/`
4. Create migration: `dotnet ef migrations add FeatureName`
5. Apply migration: `dotnet ef database update`
6. Create repository interface and implementation
7. Create service layer in `GymBusinessLogic/Services/`
8. Create controller in `GymManagement/Controllers/`
9. Create views in `GymManagement/Views/`
10. Register services in `Program.cs`

## 📝 Migrations

### View Existing Migrations
```bash
cd GymManagement
dotnet ef migrations list --project ../GymDataAccess
```

### Create New Migration
```bash
cd GymManagement
dotnet ef migrations add MigrationName --project ../GymDataAccess
```

### Revert to Previous Migration
```bash
cd GymManagement
dotnet ef database update PreviousMigrationName --project ../GymDataAccess
```

## 🐛 Troubleshooting

### Issue: Database Connection Failed
**Solution:**
- Verify SQL Server is running
- Check connection string in `appsettings.json`
- Ensure database name is correct
- For LocalDB: Use `Server=(localdb)\mssqllocaldb` instead of `.`

### Issue: Migration Fails
**Solution:**
```bash
# Remove last migration
dotnet ef migrations remove --project ../GymDataAccess

# Revert database to previous state
dotnet ef database update PreviousMigrationName --project ../GymDataAccess
```

### Issue: Port Already in Use
**Solution:**
- Change port in `Properties/launchSettings.json`
- Or use a different port: `dotnet run --urls "https://localhost:8000"`

### Issue: Static Files Not Loading
**Solution:**
- Ensure `wwwroot` folder exists
- Run `dotnet run` from the correct directory
- Check Bootstrap and jQuery paths in views

## 📚 Additional Resources

- [Microsoft ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/ef/core/)
- [AutoMapper Documentation](https://docs.automapper.org/)
- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.0/)

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is open-source and available under the MIT License.

## 👨‍💻 Author

**Sa-Hesham**

- GitHub: [@Sa-Hesham](https://github.com/Sa-Hesham)
- Repository: [GymManagementSystem](https://github.com/Sa-Hesham/GymManagementSystem)

---

**Last Updated**: 2024

For issues or questions, please open an issue on the GitHub repository.
