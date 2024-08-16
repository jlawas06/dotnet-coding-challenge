# PizzaXYZ.Backend

This repository contains the backend implementation for PizzaXYZ, built using Clean Architecture principles.

## Architecture

PizzaXYZ.Backend follows the Clean Architecture pattern, which promotes separation of concerns and maintainability. The project is structured into layers, each with a specific responsibility:

1. Core (Domain and Application layers)
2. Infrastructure
3. Presentation (API)

## Technologies and Packages

- .NET: The primary framework used for building the application
- Entity Framework: For database operations and ORM
- AutoMapper: For object-to-object mapping
- MediatR: For implementing the mediator pattern and handling requests/responses
- CsvHelper: For reading and writing CSV files

## Getting Started

### Prerequisites

- .NET SDK (version X.X or later)
- SQL Server (or your preferred database supported by Entity Framework)

### Running the Project

1. Clone the repository:
   ```
   git clone https://github.com/jlawas06/dotnet-coding-challenge.git
   cd PizzaXYZ.Backend
   ```

2. Restore dependencies:
   ```
   dotnet restore
   ```

3. Update the database connection string in `appsettings.json` file located in the API project.

4. Apply database migrations:
   ```
   dotnet ef database update
   ```

5. Run the application:
   ```
   dotnet run --project src/PizzaXYZ.Backend.API
   ```

6. The API should now be running on `https://localhost:7047` (and `http://localhost:5057`).

## Project Structure

- `src/PizzaXYZ.Backend.Domain`: Contains domain entities, enums, exceptions, interfaces, types and logic
- `src/PizzaXYZ.Backend.Application`: Contains business logic, interfaces and types
- `src/PizzaXYZ.Backend.Infrastructure`: Contains classes for accessing external resources such as databases, file systems, web services, etc.
- `src/PizzaXYZ.Backend.API`: Contains controllers and models for the API endpoints

## Contributing

Please read `CONTRIBUTING.md` for details on our code of conduct, and the process for submitting pull requests.

## License

This project is licensed under the MIT License - see the `LICENSE.md` file for details.