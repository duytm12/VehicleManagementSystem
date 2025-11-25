using System;

namespace App.Demos.GoodPractices;

// ============================================================================
// ✅ GOOD PRACTICES - SOLID PRINCIPLES & CLEAN ARCHITECTURE
// ============================================================================
// Compare these with SOLID_BadPractices.cs to see the differences

// ============================================================================
// ✅ GOOD PRACTICE 1: Following Single Responsibility Principle (SRP)
// ============================================================================
// Each class has ONE reason to change

// Domain Model - Only holds data
public class Car
{
    public int Year { get; set; }
    public string Make { get; set; }
    public decimal Price { get; set; }
}

// Repository - Only handles data persistence
public interface ICarRepository
{
    void Save(Car car);
    Car GetById(int id);
}

public class CarRepository : ICarRepository
{
    public void Save(Car car)
    {
        Console.WriteLine($"Saving {car.Make} to database...");
    }

    public Car GetById(int id)
    {
        return new Car { Year = 2020, Make = "Toyota", Price = 25000 };
    }
}

// Service - Only handles business logic
public interface ITaxCalculator
{
    decimal CalculateTax(Car car);
}

public class TaxCalculator : ITaxCalculator
{
    public decimal CalculateTax(Car car)
    {
        return car.Price * 0.10m; // 10% tax
    }
}

// Service - Only handles notifications
public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine($"Sending email to {to}: {subject}");
    }
}

// ============================================================================
// ✅ GOOD PRACTICE 2: Following Open/Closed Principle (OCP)
// ============================================================================
// Open for extension, closed for modification

public interface IDiscountStrategy
{
    decimal CalculateDiscount(decimal price);
}

public class RegularCustomerDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal price) => price * 0.05m;
}

public class PremiumCustomerDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal price) => price * 0.10m;
}

public class VIPCustomerDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal price) => price * 0.15m;
}

// GOOD: Can add new discount types without modifying this class
public class DiscountCalculator
{
    private readonly IDiscountStrategy _strategy;

    public DiscountCalculator(IDiscountStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CalculateDiscount(decimal price)
    {
        return _strategy.CalculateDiscount(price);
    }
}

// Easy to extend - just add new class implementing IDiscountStrategy
public class StudentDiscount : IDiscountStrategy
{
    public decimal CalculateDiscount(decimal price) => price * 0.20m;
}

// ============================================================================
// ✅ GOOD PRACTICE 3: Following Dependency Inversion Principle (DIP)
// ============================================================================
// Depend on abstractions, not concretions

// Abstractions (interfaces)
public interface IDatabase
{
    void Save(Car car);
}

public interface IEmailService2
{
    void Send(string to, string subject, string body);
}

// Concrete implementations
public class SqlServerDatabase : IDatabase
{
    public void Save(Car car) => Console.WriteLine("Saving to SQL Server...");
}

public class MongoDatabase : IDatabase
{
    public void Save(Car car) => Console.WriteLine("Saving to MongoDB...");
}

public class SmtpEmailService : IEmailService2
{
    public void Send(string to, string subject, string body) => Console.WriteLine("Sending via SMTP...");
}

public class SendGridEmailService : IEmailService2
{
    public void Send(string to, string subject, string body) => Console.WriteLine("Sending via SendGrid...");
}

// GOOD: Depends on abstractions, can easily swap implementations
public class CarService
{
    private readonly IDatabase _database;
    private readonly IEmailService2 _emailService;

    // Dependency Injection - dependencies injected from outside
    public CarService(IDatabase database, IEmailService2 emailService)
    {
        _database = database;
        _emailService = emailService;
    }

    public void ProcessCar(Car car)
    {
        _database.Save(car);
        _emailService.Send("admin@example.com", "New car added", car.Make);
    }
}

// ============================================================================
// ✅ GOOD PRACTICE 4: Following Interface Segregation Principle (ISP)
// ============================================================================
// Clients should not be forced to depend on interfaces they don't use

// Segregated interfaces - small, focused interfaces
public interface IEngine
{
    void Start();
    void Stop();
}

public interface IDrivable
{
    void Drive();
}

public interface IFlyable
{
    void Fly();
}

public interface ISailable
{
    void Sail();
}

// GOOD: Classes only implement what they need
public class Car3 : IEngine, IDrivable
{
    public void Start() => Console.WriteLine("Car engine started");
    public void Stop() => Console.WriteLine("Car engine stopped");
    public void Drive() => Console.WriteLine("Car driving");
}

public class Airplane2 : IEngine, IFlyable
{
    public void Start() => Console.WriteLine("Airplane engine started");
    public void Stop() => Console.WriteLine("Airplane engine stopped");
    public void Fly() => Console.WriteLine("Airplane flying");
}

public class Boat : IEngine, ISailable
{
    public void Start() => Console.WriteLine("Boat engine started");
    public void Stop() => Console.WriteLine("Boat engine stopped");
    public void Sail() => Console.WriteLine("Boat sailing");
}

// ============================================================================
// ✅ GOOD PRACTICE 5: Following Clean Architecture - Proper Layering
// ============================================================================

// ===== DOMAIN LAYER (Core Business Logic) =====
namespace App.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public decimal Price { get; set; }

        // Business rules in domain model
        public void Validate()
        {
            if (Year < 1900)
                throw new ArgumentException("Year must be >= 1900");
            if (Price < 0)
                throw new ArgumentException("Price cannot be negative");
            if (string.IsNullOrWhiteSpace(Make))
                throw new ArgumentException("Make is required");
        }
    }
}

// ===== APPLICATION LAYER (Use Cases) =====
namespace App.Application
{
    using App.Domain;

    public interface ICarRepository
    {
        void Add(Car car);
        Car GetById(int id);
    }

    // Use case - application service
    public class AddCarUseCase
    {
        private readonly ICarRepository _repository;

        public AddCarUseCase(ICarRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int year, string make, decimal price)
        {
            var car = new Car
            {
                Year = year,
                Make = make,
                Price = price
            };

            car.Validate(); // Business validation
            _repository.Add(car); // Persistence
        }
    }
}

// ===== INFRASTRUCTURE LAYER (Data Access) =====
namespace App.Infrastructure
{
    using App.Domain;
    using App.Application;

    public class CarRepository : ICarRepository
    {
        // Database implementation details
        public void Add(Car car)
        {
            Console.WriteLine($"Saving {car.Make} to database...");
            // Actual database code here
        }

        public Car GetById(int id)
        {
            Console.WriteLine($"Retrieving car {id} from database...");
            return new Car { Id = id, Year = 2020, Make = "Toyota", Price = 25000 };
        }
    }
}

// ===== PRESENTATION LAYER (UI/API) =====
namespace App.Presentation
{
    using App.Application;
    using App.Infrastructure;

    public class CarController
    {
        private readonly AddCarUseCase _addCarUseCase;

        public CarController()
        {
            // Dependency injection - infrastructure injected into application
            var repository = new CarRepository();
            _addCarUseCase = new AddCarUseCase(repository);
        }

        public void AddCar(int year, string make, decimal price)
        {
            try
            {
                _addCarUseCase.Execute(year, make, price);
                Console.WriteLine("Car added successfully!"); // UI concern
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // UI concern
            }
        }
    }
}

// ============================================================================
// SUMMARY: Key Principles
// ============================================================================
/*
SOLID Principles:
- S: Single Responsibility - Each class has one reason to change
- O: Open/Closed - Open for extension, closed for modification
- L: Liskov Substitution - Subtypes must be substitutable for their base types
- I: Interface Segregation - Many specific interfaces > one fat interface
- D: Dependency Inversion - Depend on abstractions, not concretions

Clean Architecture:
- Separation of Concerns - Each layer has a specific responsibility
- Dependency Rule - Inner layers don't depend on outer layers
- Domain at the Center - Business logic is independent of frameworks
- Testability - Easy to test by swapping implementations
*/

