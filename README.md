# Project CleanArchCQRS 🚀

## Description
This project is a .NET 8 application following the principles of Clean Architecture, utilizing CQRS (Command Query Responsibility Segregation), the Unit of Work pattern for transaction control, MediatR for implementing the Mediator pattern, FluentValidation for input data validation, SQL Server as a relational database, and Entity Framework Core and Dapper for data access.

## Prerequisites
- Installed .NET 8 SDK
- Installed and configured SQL Server

## Configuration
1. Clone this repository to your local machine.
2. In the root directory of the project, run the command `dotnet restore` to restore the project dependencies.
3. Configure the SQL Server connection string in the `appsettings.json` file in the project of your choice (usually `API`, `Application`, or `Infrastructure`).
4. Run the command `dotnet ef database update` to apply pending migrations and create the database.

## Project Structure
The project is structured according to the principles of Clean Architecture, with the following main directories:

- `Application`: Contains application logic, including command and query handlers.
- `Domain`: Contains domain entities and repository interface definitions.
- `Infrastructure`: Contains the concrete implementation of interfaces defined in the domain, including database access and UoW implementations.
- `API`: Contains API controllers and dependency injection configuration.

## Running the Project
1. Navigate to the root directory of the project.
2. Run the command `dotnet run` to start the application.
3. The API will be available at `https://localhost:{PORT}`.

## Technologies Used
- .NET 8
- CQRS
- Clean Architecture
- Entity Framework Core
- Dapper
- MediatR
- FluentValidation
- SQL Server
