# ASP.NET Core 10 (.NET 10) – True Ultimate Guide
🌐 **GitHub Repository:** https://github.com/youssef-mohammed317/Udemy.ASP.NetCoreUlitimateGuide.Assingments

🎓 **Course Reference:** https://www.udemy.com/course/asp-net-core-true-ultimate-guide-real-project/

📜 **Certificate:** https://drive.google.com/file/d/1w7kqYdkPweA9NomnInLiwOeb6sWYEXXQ/view?usp=drive_link

---
## Overview
This repository contains my complete, hands-on journey through **"ASP.NET Core 10 (.NET 10) | True Ultimate Guide"** — a 34-section, 432-lecture course covering ASP.NET Core MVC and Web API from the ground up to senior-level, production-grade practices.

Every section's assignment was implemented and committed as the course progressed, evolving through several real applications — a Weather App, a Bank App, an e-Commerce Orders App, and the course's flagship **Stocks Trading Platform**, which was progressively extended with Entity Framework Core, Repository Pattern, unit/integration testing (xUnit + Moq + AutoFixture), Serilog logging, Filters, SOLID Principles, and Clean Architecture.

The course has been completed end-to-end.
---
## Architecture & Code Organization
The codebase is organized **section-by-section**, mirroring the course structure, with each assignment committed individually so reviewers can trace how each app evolved feature by feature.

### 1️⃣ ASP.NET Core MVC Fundamentals
- HTTP, Middleware, Routing, Controllers & IActionResult
- Model Binding & Validation (custom validators, custom model binders, input formatters)
- Razor Views, Layout Views, Partial Views, and View Components
- Dependency Injection (service lifetimes, Autofac, best practices)

### 2️⃣ Configuration, Data & Testing
- Environments, Configuration (Options Pattern, Secrets Manager) & HttpClient
- Entity Framework Core (migrations, stored procedures, Fluent API, relations, async operations)
- xUnit testing built from scratch on a Contacts Manager project
- Advanced testing: Moq, AutoFixture, Fluent Assertions, Repository Pattern, Integration Tests

### 3️⃣ Production-Grade Practices
- Logging with ILogger and Serilog (file, database, and Seq sinks)
- Filters (Action, Result, Resource, Authorization, Exception filters)
- Centralized Error Handling
- SOLID Principles and Clean Architecture (Core / Infrastructure / UI / Tests layering)

### 4️⃣ Security & Web API
- ASP.NET Core Identity, Roles, Areas, and Authorization Policies
- Web API Controllers with EF Core, ProblemDetails, Swagger/OpenAPI & API Versioning
- Angular consumption of the API with CORS configuration
- JWT Authentication with Refresh Tokens
- Minimal API (routing, endpoint filters, IResult)
---
## Key Features
- **End-to-End Coverage:** Every section of the course, from HTTP basics to Clean Architecture and JWT security, is implemented as working code.
- **Real Applications, Not Snippets:** Concepts are practiced through full mini-apps — Weather App, Bank App, e-Commerce Orders, and a full Stocks Trading Platform.
- **Test-Driven Practices:** Heavy use of xUnit, Moq, and AutoFixture across services, repositories, and controllers.
- **Professional Architecture:** Repository Pattern, Dependency Injection, SOLID Principles, and Clean Architecture applied to the same evolving project.
- **Section-by-Section Commits:** Git history tracks the exact progression through the course, making it easy to review any topic in isolation.
---
## Tech Stack
- **Framework:** ASP.NET Core (.NET 10) — MVC & Web API
- **Data Access:** Entity Framework Core
- **Testing:** xUnit, Moq, AutoFixture, Fluent Assertions
- **Logging:** Serilog (Console, File, Seq sinks)
- **Security:** ASP.NET Core Identity, JWT Authentication
- **Frontend Interop:** Angular (for CORS/Web API consumption module)
- **Architecture:** Repository Pattern, SOLID Principles, Clean Architecture
- **Version Control:** Git & GitHub
---
## Author
**Youssef Mohammed**
---

## 📚 Full Course Curriculum

<details>
<summary>Click to expand all 34 sections / 432 lectures</summary>

### 1. Introduction
*9 lectures • 16min*

- Introduction to Asp.Net Core
- WebForms vs Asp.Net Mvc vs Asp.Net Core
- Section Cheat Sheet (PPT)
- Section 1 Interview Questions
- Where to download the Source Code
- How to download Notes
- New features of Asp.Net Core 10
- What if I'm interested in Web API only?
- Projects in this Course
- How to watch videos effectively (Best study method?)

### 2. Getting Started [MVC and Web API]
*6 lectures • 47min*

- Setup Environment
- Create First Asp.Net Core App
- Kestrel and Other Servers
- launchSettings.json
- Notes
- Section Cheat Sheet (PPT)
- Section 2 Interview Questions

### 3. HTTP [MVC and Web API]
*12 lectures • 1hr 58min*

- Introduction to HTTP
- HTTP Response
- HTTP Status Codes
- HTTP Response Headers
- HTTP Request
- Query String
- HTTP Request Headers
- Postman
- HTTP Get vs Post - Part 1
- HTTP Get vs Post - Part 2
- Notes
- Section Cheat Sheet (PPT)
- Section 3 Interview Questions
- Math app though HTTP GET

### 4. Middleware [MVC and Web API]
*10 lectures • 1hr 29min*

- Intro to Middleware
- Run
- Middleware Chain
- Custom Middleware Class
- Custom Middleware Extensions
- Custom Conventional Middleware Class
- The Right Order of Middleware
- UseWhen
- Notes
- Section Cheat Sheet (PPT)
- Section 4 Interview Questions
- Login using Middleware

### 5. Routing [MVC and Web API]
*13 lectures • 2hr 24min*

- Intro to Routing
- Map, MapGet, MapPost
- Route Parameters
- Default Parameters
- Optional Parameters
- Route Constraints - Part 1
- Route Constraints - Part 2
- Route Constraints - Part 3
- Custom Route Constraint Class
- EndPoint Selection Order
- WebRoot and UseStaticFiles
- Notes
- Section Cheat Sheet (PPT)
- Section 5 Interview Questions
- Countries app using Routing

### 6. Controllers & IActionResult [MVC and Web API]
*12 lectures • 2hr 32min*

- Creating Controllers
- Multiple Action Methods
- Takeaways about Controllers
- ContentResult
- JsonResult
- File Results
- IActionResult
- Status Code Results
- Redirect Results - Part 1
- Redirect Results - Part 2
- Notes
- Section Cheat Sheet (PPT)
- Section 6 Interview Questions
- Bank app using Controllers

### 7. Model Binding and Validations [MVC and Web API]
*21 lectures • 3hr 59min*

- Overview of Model Binding
- Query String vs Route Data
- FromQuery and FromRoute
- Model Class
- form-urlencoded and form-data
- Introduction to Model Validations
- Model State
- All Model Validations - Part 1
- All Model Validations - Part 2
- Custom Validation
- Custom Validation with Multiple Properties
- IValidatableObject
- Bind and BindNever
- Custom Model Binders
- Model Binder Providers
- Collection Binding
- FromHeader
- FromBody
- Input Formatters
- Notes
- Section Cheat Sheet (PPT)
- Section 7 Interview Questions
- e-Commerce Orders App

### 8. Razor Views [MVC]
*20 lectures • 5hr 20min*

- MVC Architecture Pattern
- Views
- Code Blocks and Expressions
- If
- Switch
- Foreach
- for
- Literal
- Html.Raw
- ViewData - Part 1
- ViewData - Part 2
- ViewBag
- Strongly Typed Views - Part 1
- Strongly Typed Views - Part 2
- Strongly Typed Views with Multiple Models
- _ViewImports.cshtml
- Shared Views
- Notes
- Section Cheat Sheet (PPT)
- Section 8 Interview Questions
- Weather App

### 9. Layout Views [MVC]
*10 lectures • 1hr 23min*

- Creating Layout Views - Part 1
- Creating Layout Views - Part 2
- Layout View for Multiple Views
- ViewData in Layout Views
- _ViewStart.cshtml
- Dynamic Layout Views
- Layout Views Sections
- Nested Layout Views
- Notes
- Section Cheat Sheet (PPT)
- Section 9 Interview Questions
- Weather App with Layout Views

### 10. Partial Views [MVC]
*6 lectures • 1hr 12min*

- Partial Views with ViewData
- Strongly Typed Partial Views
- PartialViewResult
- Notes
- Section Cheat Sheet (PPT)
- Section 10 Interview Questions
- Weather App with Partial Views

### 11. View Components [MVC]
*8 lectures • 1hr 32min*

- Creating View Components - Part 1
- Creating View Components - Part 2
- View Components with ViewData
- Strongly Typed View Components
- View Components with Parameters
- ViewComponentResult
- Notes
- Section Cheat Sheet (PPT)
- Section 11 Interview Questions
- Weather App with View Components

### 12. Dependency Injection [MVC and Web API]
*15 lectures • 2hr 57min*

- Services - Part 1
- Services - Part 2
- Dependency Inversion Principle
- Inversion of Control
- Dependency Injection
- Method Injection - FromService
- Transient, Scoped, Singleton - Part 1
- Transient, Scoped, Singleton - Part 2
- Service Scope
- AddTransient(), AddScoped(), AddSingleton()
- View Injection
- Best Practices for DI
- Autofac
- Notes
- Section Cheat Sheet (PPT)
- Section 12 Interview Questions
- Weather App with Dependency Injection

### 13. Environments [MVC and Web API]
*7 lectures • 59min*

- Introduction to Environments
- Environment in Launch Settings
- Environment in Controller
- Environment Tag Helper
- Process Level Environment
- Notes
- Section Cheat Sheet (PPT)

### 14. Configuration & HttpClient [MVC and Web API]
*14 lectures • 2hr 49min*

- Configuration Basics
- IConfiguration in Controller
- Hierarchical Configuration
- Options Pattern
- Configuration as Service
- Environment Specific Configuration
- Secrets Manager
- Environment Variables Configuration
- Custom Json Configuration
- Http Client - Part 1
- Http Client - Part 2
- Http Client - Part 3
- Notes
- Section Cheat Sheet (PPT)
- Section 14 Interview Questions
- Social Media Links
- Stocks App with Configuration

### 15. xUnit [MVC and Web API]
*31 lectures • ~6hr*

- Project Overview | Contacts Manager
- xUnit Basics
- Add Country - xUnit Test - Part 1
- Add Country - xUnit Test - Part 2
- Add Country - xUnit Test - Part 3
- Add Country - Implementation
- Get All Countries - xUnit Test
- Get All Countries - Implementation
- Get Country by Country ID - xUnit Test
- Get Country by Country ID - Implementation
- Add Person - Creating Models - Part 1
- Add Person - Creating Models - Part 2
- Add Person - xUnit Test
- Add Person - Implementation
- Add Person - Validation
- Get Person by Person ID - xUnit Test
- Get Person by Person ID - Implementation
- Get All Persons - xUnit Test
- Get All Persons - Implementation
- TestOutputHelper
- Get Filtered Persons - xUnit Test
- Get Filtered Persons - Implementation
- Get Sorted Persons - xUnit Test
- Get Sorted Persons - Implementation
- Update Person - Creating DTO
- Update Person - xUnit Test
- Update Person - Implementation
- Delete Person - xUnit Test
- Delete Person - Implementation
- Notes
- Section Cheat Sheet (PPT)
- Section 15 Interview Questions
- Stocks App with xUnit

### 16. CRUD Operations [MVC]
*12 lectures • 2hr 56min*

- Getting Started with UI
- Mock Data
- List View
- Search in List View - Part 1
- Search in List View - Part 2
- Sort in List View - Part 1
- Sort in List View - Part 2
- Create View - Part 1
- Create View - Part 2
- Attribute Routing
- Notes
- Section Cheat Sheet (PPT)
- Section 16 Interview Questions
- Stocks App with CRUD Operations

### 17. Tag Helpers [MVC]
*11 lectures • 3hr 27min*

- Introduction to Tag Helpers
- Form Tag Helpers
- Input Tag Helpers - Part 1
- Input Tag Helpers - Part 2
- Client Side Validations
- Script Tag Helpers
- Image Tag Helpers
- Edit View
- Delete View
- Notes
- Section Cheat Sheet (PPT)
- Section 17 Interview Questions
- Stocks App with Tag Helpers

### 18. EntityFrameworkCore [MVC and Web API]
*26 lectures • 6hr 22min*

- Introduction to EntityFrameworkCore
- EFCore Approaches
- DbContext and DbSet
- Connection String
- Seed Data
- Migrations
- EF CRUD Operations
- How EF Query Works
- EF Stored Proc
- EF Stored Proc with Parameters
- Changes in Table Structure
- Fluent API - Part 1
- Fluent API - Part 2
- Table Relations with EF
- Async EF Operations
- Async Controller Action Methods
- Async Unit Test Methods
- Generate PDF Files
- Generate CSV Files - Part 1
- Generate CSV Files - Part 2
- Generate Excel Files
- Excel to Database Upload - Part 1
- Excel to Database Upload - Part 2
- Excel to Database Upload - Part 3
- Notes
- Section Cheat Sheet (PPT)
- Section 18 Interview Questions
- Stocks App with EntityFrameworkCore

### 19. Advanced Unit Testing - Moq & Repository Pattern [MVC and Web API]
*22 lectures • 5hr 48min*

- Best Practices of Unit Tests
- Mock DbContext
- AutoFixture - Part 1
- AutoFixture - Part 2
- Fluent Assertions - Part 1
- Fluent Assertions - Part 2
- Fluent Assertions Cheat Sheet
- Introduction to Repository
- Repository Implementation - Part 1
- Repository Implementation - Part 2
- Invoke Repository in Service - Part 1
- Invoke Repository in Service - Part 2
- Pros and Cons of Repository Pattern
- Mock Repository - Part 1
- Mock Repository - Part 2
- Mock Repository - Part 3
- Controller Unit Test - Part 1
- Controller Unit Test - Part 2
- Integration Test
- Integration Test with Response Body
- Notes
- Section Cheat Sheet (PPT)
- Section 19 Interview Questions
- Stocks App with Moq

### 20. Logging and Serilog [MVC and Web API]
*17 lectures • 2hr 34min*

- Introduction Logging
- ILogger
- Logging Configuration
- Logging Providers
- ILogger in Controller
- HTTP Logging
- HTTP Logging Options
- Serilog Basics
- Serilog File Sink
- Serilog Database Sink
- Serilog Seq
- Serilog RequestId
- Serilog Enrichers
- Serilog IDiagnosticContext
- Serilog Timings
- Notes
- Section Cheat Sheet (PPT)
- Section 20 Interview Questions
- Stocks App with Logging

### 21. Filters [MVC and Web API]
*27 lectures • 7hr 11min*

- Introduction to Filters
- Action Filter
- Parameter Validation in Action Filter
- ViewData in Action Filter
- Serilog Structured Logging
- Filter Arguments
- Global Filters
- Custom Order of Filters
- IOrderedFilter
- Async Filters
- Short Circuiting Action Filter
- Result Filter
- Resource Filter
- Authorization Filter
- Exception Filter
- Impact of Short Circuiting
- IAlwaysRunResultFilter
- Filter Overrides
- Service Filter
- Filter Attribute Classes
- IFilterFactory
- Filters vs Middleware
- UI Enhancements - Part 1
- UI Enhancements - Part 2
- Configure Services Extension
- Notes
- Section Cheat Sheet (PPT)
- Section 21 Interview Questions
- Stocks App with Filters

### 22. Error Handling [MVC and Web API]
*5 lectures • 59min*

- Exception Handling Middleware
- Custom Exceptions
- UseExceptionHandler
- Notes
- Section Cheat Sheet (PPT)
- Section 22 Interview Questions
- Stocks App with Error Handling

### 23. SOLID Principles [MVC and Web API]
*10 lectures • 1hr 54min*

- Overview of SOLID Principles
- Dependency Inversion Principle (Revision)
- Single Responsibility Principle
- Interface Segregation Principle
- ISP in Tests
- Open/Closed Principle
- OCP with Inheritance
- Liskov Substitution Principle
- Notes
- Section Cheat Sheet (PPT)
- Section 23 Interview Questions
- Stocks App with SOLID Principles

### 24. Clean Architecture [MVC and Web API]
*7 lectures • 1hr 18min*

- Overview of Clean Architecture
- Core
- Infrastructure
- UI
- Tests
- Notes
- Section Cheat Sheet (PPT)
- Section 24 Interview Questions
- Stocks App with Clean Architecture

### 25. Identity, Authorization, Security [MVC and Web API]
*23 lectures • 5hr 3min*

- Introduction to Identity
- Creating Models
- Register View
- Adding Identity
- User Manager
- SignIn Manager
- Login/Logout Buttons
- Active Nav Link
- Password Complexity Configuration
- Login View
- Authorization Policy
- ReturnUrl
- Remote Validation
- Conventional Routing
- User Roles
- Areas
- Role Based Authentication
- Custom Authorization Policies
- HTTPS
- XSRF - Part 1
- XSRF - Part 2
- Notes
- Section Cheat Sheet (PPT)
- Section 25 Interview Questions

### 26. Asp.Net Core Web API [Web API]
*12 lectures • 3hr 27min*

- Introduction to Web API
- Creating Web API Project
- Web API Controllers
- EntityFrameworkCore with Web API
- Web API Controllers with EF Core - Part 1
- Web API Controllers with EF Core - Part 2
- Web API Controllers with EF Core - Part 3
- ProblemDetails
- IActionResult vs ActionResult
- ControllerBase
- Notes
- Section Cheat Sheet (PPT)
- Section 26 Interview Questions
- Orders Web API

### 27. Swagger / Open API [Web API]
*8 lectures • 1hr 15min*

- Swagger / Open API - Basics
- Documentation Comments
- Content Negotiation
- API Versions - Part 1
- API Versions - Part 2
- API Versions - Part 3
- Notes
- Section Cheat Sheet (PPT)
- Section 27 Interview Questions

### 28. Angular and CORS [Web API]
*15 lectures • 2hr 36min*

- Creating Angular App
- Angular AppComponent
- Angular Service
- Angular Cities Component
- Invoking Web API Services
- CORS Basics
- CORS Configuration
- Default CORS Policy
- Custom CORS Policy
- Angular POST
- Angular PUT
- Angular DELETE
- Clean Architecture with Web API
- Notes
- Section Cheat Sheet (PPT)
- Section 28 Interview Questions

### 29. JWT & Web API Authentication [Web API]
*13 lectures • 4hr 10min*

- Identity with Web API
- Register Endpoint
- Register UI
- Login Endpoint
- Login UI
- JWT Basics
- Generating JWT Tokens - Part 1
- Generating JWT Tokens - Part 2
- Authorization with JWT
- Refresh Tokens - Part 1
- Refresh Tokens - Part 2
- Notes
- Section Cheat Sheet (PPT)
- Section 29 Interview Questions

### 30. Minimal API [Web API]
*10 lectures • 1hr 46min*

- Introduction to Minimal API
- Creating Basic Minimal API
- GET and POST with Minimal API
- Route Parameters
- MapGroups
- IResult
- End Point Filters
- IEndpointFilter
- Notes
- Section Cheat Sheet (PPT)
- Section 30 Interview Questions

### 31. Extra: C# Essentials (Optional)
*18 lectures • 4hr 31min*

- Extension Methods
- Anonymous Methods
- Lambda Expressions
- Dictionary
- Collection of Objects
- Object Relations
- Interfaces
- LINQ Basics
- LINQ - OrderBy
- LINQ - First and FirstOrDefault
- LINQ - Last and LastOrDefault
- LINQ - ElementAt and ElementAtOrDefault
- LINQ - Single and SingleOrDefault
- LINQ - Select
- LINQ - Min and Max
- C# 9 Top Level Statements
- C# 9 Nullable Reference Types
- Section Cheat Sheet (PPT)

### 32. Practical Test
*2 items*

- Final Practical Test - Level 1
- Final Practical Test - Level 2

### 33. Outro
*1 lecture • 1min*

- An Outro note from the Author

### 34. Bonus
*1 lecture • 2min*

- Bonus Lecture

</details>
