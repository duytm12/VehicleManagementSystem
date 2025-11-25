# Console Application Template

A structured template for creating console applications in C# 10.0 with .NET 10.0.

## Project Structure

```
ConsoleApp/
├── Application.cs          # Main application orchestrator
├── Program.cs              # Entry point
├── Models/                 # Data models (DTOs)
│   └── ExampleModel.cs
├── Services/               # Business logic layer
│   └── ExampleService.cs
├── Helpers/                # Utility classes
│   ├── InputHelpers.cs    # Input validation helpers
│   └── OutPutHelpers.cs   # Output formatting helpers
└── [ProjectName].csproj    # Project file
```

## Architecture Pattern

- **Program.cs**: Entry point - minimal code, just instantiates and runs Application
- **Application.cs**: Orchestrator - coordinates the application flow, calls services
- **Services/**: Business logic - contains calculation/processing logic (unit testable)
- **Models/**: Data structures - simple DTOs with properties only
- **Helpers/**: Utilities - reusable helper functions for I/O operations

## Getting Started

1. **Rename the project**:
   - Rename `ConsoleApp.csproj` to your project name
   - Update namespace in all files from `ConsoleApp` to your namespace
   - Update solution file name if needed

2. **Customize Application.cs**:
   - Add your application logic in the `Run()` method
   - Use `InputHelpers` to get user input
   - Use `Services` for business logic
   - Use `OutPutHelpers` to display results

3. **Create your Models**:
   - Add data models in the `Models/` folder
   - Models should only contain properties

4. **Implement your Services**:
   - Add business logic classes in the `Services/` folder
   - Services are called from `Application.cs`

5. **Extend Helpers** (optional):
   - Add more utility functions to `InputHelpers` or `OutPutHelpers` as needed

## Requirements

- .NET 10.0 SDK or later

## Running the Application

```bash
dotnet run
```

## Building the Application

```bash
dotnet build
```

## Testing Strategy

- **Application.cs**: Integration tests (test the flow)
- **Services**: Unit tests (test business logic)
- **Helpers**: Unit tests (test utility functions)
- **Models**: Usually no tests needed (just data)

## Best Practices

- Keep `Program.cs` minimal - just entry point
- Put all orchestration logic in `Application.cs`
- Keep business logic in `Services/` for testability
- Use `Models/` for data transfer only
- Use `Helpers/` for reusable utility functions

