# Contacts Management API

A Contacts Management API built with .NET Core and C#. This project demonstrates a layered architecture, following the principles of SOLID and clean coding practices, making it scalable and easy to maintain.

## Project Overview

The Contacts Management API is designed to perform CRUD operations on contact records, with various functionalities implemented across different layers. Key components include model validation, dependency injection, and a structured folder organization to ensure modular development.

## Technologies Used

- **.NET Core**: Backend framework for building RESTful APIs.
- **Entity Framework Core**: ORM for database operations.
- **SQL Server**: Relational database.
- **FluentValidation**: Model validation library.
- **Swagger**: API documentation and testing tool.

## Folder Structure

### 1. **Controllers**
   - **ContactController**: Handles HTTP requests and responses for managing contacts, including methods for:
     - **GetContacts**: Fetches all contacts.
     - **CreateContacts**: Creates a new contact with model validation.
     - **UpdateContact**: Updates an existing contact.
     - **DeleteContact**: Deletes a contact by ID.
   - **Features**: Uses FluentValidation for model validation and integrates with Swagger for API documentation.

### 2. **Database**
   - **ContactsDbContext**: Sets up the database context with `DbSet` for the `Contacts` model.
   - **Connection Configuration**: The connection string is stored in `appsettings.json` for easy access and security.

### 3. **Functionality**
   - **IContactOperations**: Interface defining methods for CRUD operations:
     - `Add`, `GetAll`, `Find`, `Remove`, `Update`, `CheckValidityUserKey`.
   - Allows flexibility and adheres to the **Dependency Inversion Principle**.

### 4. **Implementation**
   - **ContactsOperation**: Implements the `IContactOperations` interface, providing functionality for adding, retrieving, updating, and deleting contact data.
   - **Features**: Ensures separation of concerns by encapsulating business logic separately from the database logic.

### 5. **Models**
   - **Contacts Model**: Defines properties such as `FirstName`, `LastName`, `Email`, `MobilePhone`, etc., representing a contact record.
   - **FluentModelValidation**: Contains server-side validation for model properties using FluentValidation.
     - Example rules include email validation, phone number formatting, and required fields for `FirstName`, `LastName`, and `Company`.

### 6. **Pattern**
   - **ContactMapper**: Implements Fluent API for configuring `Contacts` entity mapping to the database.
   - **Key Configurations**: Defines the primary key and required fields.

### 7. **Configuration Files**
   - **appsettings.json**: Stores database connection string and application settings.
   - **Program.cs**: Configures services such as DbContext, dependency injection for `IContactsOperations`, and validation with FluentValidation.

## Key Features

- **CRUD Operations**: Create, retrieve, update, and delete contacts.
  - **CreateContact**: Adds a new contact.
  - **GetContacts**: Fetches all contacts.
  - **UpdateContact**: Updates the contact details.
  - **DeleteContact**: Removes a contact by ID.
- **Model Validation**: Ensures data integrity with validation rules on fields like `FirstName`, `LastName`, `Email`, and `MobilePhone`.
- **Dependency Injection**: Ensures loose coupling and easy testing.
- **Fluent API Configurations**: Defines mappings and constraints for the database model.
- **Swagger Integration**: For easy API documentation and testing.
- **SOLID Principles**: Applies SOLID design principles to make the code modular, reusable, and scalable.

## Getting Started

### Prerequisites
- .NET Core SDK
- SQL Server
- Visual Studio or VS Code

### Setting Up the Project
1. Clone the repository.
2. Set up the database connection string in `appsettings.json`.
3. Run database migrations using Entity Framework Core to create tables.
4. Launch the API using Visual Studio or CLI.
5. Also run the command `dotnet restore`.

### Usage
- Use Swagger or tools like Postman to interact with the API.
- Test endpoints to perform CRUD operations on contact data.
  - **POST** `/contacts`: Add a new contact.
  - **GET** `/contacts`: Get all contacts.
  - **PUT** `/contacts/{id}`: Update an existing contact.
  - **DELETE** `/contacts/{id}`: Delete a contact.

## Future Enhancements

- Implement AutoMapper for model-to-DTO mapping.
- Add unit tests for each service.
- Expand the functionality to include more complex data relationships and additional fields.

---

This project is an example of clean architecture and follows industry practices to maintain code quality and scalability.
