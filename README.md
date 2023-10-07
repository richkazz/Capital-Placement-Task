# CapitalPlacementTask

## Table of Contents

- [Introduction](#introduction)
- [Project Overview](#project-overview)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [API Documentation](#api-documentation)

## Introduction

Welcome to the CapitalPlacementTask project! This repository contains the source code for an application that manages program details, application forms, and workflow stages for a placement program.

## Project Overview

The CapitalPlacementTask project is a C# .NET application that provides the following key features:

- Managing program details, including program title, description, benefits, and more.
- Creating and updating application forms with various questions and options.
- Defining workflow stages and associated interview questions.

This project is designed to be used as a foundation for managing placement programs and can be extended to meet specific requirements.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) installed (version specified in the project)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) for development
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database for data storage

## Getting Started

To get started with the CapitalPlacementTask project, follow these steps:

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/richkazz/CapitalPlacementTask.git
   ```

2. Open the project in your preferred development environment (Visual Studio or Visual Studio Code).

3. Configure the database connection string and database name in the `appsettings.json` file:

   ```json
   "ConnectionStrings": {
      "DefaultConnection": "AccountEndpoint=your-account;AccountKey=your-key"
    },
    "Databases": {
      "DefaultDatabase": "your-database-name"
    }
   ```

4. Run the database migrations to create the necessary tables:

   ```bash
   dotnet ef database update
   ```

5. Build and run the project:

   ```bash
   dotnet run
   ```

6. Access the application at `http://localhost:7041` or the specified port in your `appsettings.json` file.

## Project Structure

The project is organized as follows:

- `Controllers`: Contains API controllers for different endpoints.
- `DTOs`: Data Transfer Objects for API requests and responses.
- `Enums`: Enumerations used throughout the project.
- `Interfaces`: Service interfaces and repository interfaces.
- `Models`: Entity classes representing data models.
- `Repositories`: Data access layer with repository implementations.
- `Services`: Business logic services for different components.
- `Common`: Utility classes and common functionality.

## API Documentation

For detailed API documentation and usage examples, refer to the [API Documentation](DOCUMENTATION.md) file.
```
