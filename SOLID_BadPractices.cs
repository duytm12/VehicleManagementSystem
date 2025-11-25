using System;

namespace App.Demos.BadPractices;

// ============================================================================
// ❌ BAD PRACTICES - SOLID PRINCIPLES & CLEAN ARCHITECTURE
// ============================================================================
// Compare these with SOLID_GoodPractices.cs to see the differences

// ============================================================================
// ❌ BAD PRACTICE 1: Violating Single Responsibility Principle (SRP)
// ============================================================================
// Problem: One class doing too many things - database, email, tax, printing
// Why it's bad: Hard to test, maintain, and change. One change affects everything.

public class Car
{
    public int Year { get; set; }
    public string Make { get; set; }
    public decimal Price { get; set; }

    // BAD: Car class is doing too many things
    public void SaveToDatabase()
    {
        // Database logic here
        Console.WriteLine("Saving to database...");
    }

    public void SendEmail()
    {
        // Email logic here
        Console.WriteLine("Sending email...");
    }

    public void CalculateTax()
    {
        // Tax calculation logic here
        Console.WriteLine("Calculating tax...");
    }

    public void PrintInvoice()
    {
        // Printing logic here
        Console.WriteLine("Printing invoice...");
    }
}

// ============================================================================
// ❌ BAD PRACTICE 2: Violating Open/Closed Principle (OCP)
// ============================================================================
// Problem: Must modify this class every time we add a new discount type
// Why it's bad: Violates "Open for extension, closed for modification"

public class DiscountCalculator
{
    // BAD: Must modify this class every time we add a new discount type
    public decimal CalculateDiscount(string customerType, decimal price)
    {
        if (customerType == "Regular")
        {
            return price * 0.05m; // 5% discount
        }
        else if (customerType == "Premium")
        {
            return price * 0.10m; // 10% discount
        }
        else if (customerType == "VIP")
        {
            return price * 0.15m; // 15% discount
        }
        // What if we need to add "Student" or "Senior"? We must modify this class!
        return 0;
    }
}

// ============================================================================
// ❌ BAD PRACTICE 3: Violating Dependency Inversion Principle (DIP)
// ============================================================================
// Problem: Depends on concrete implementation, not abstraction
// Why it's bad: Tightly coupled - hard to test, hard to change implementations

public class CarService
{
    // BAD: Depends on concrete implementation, not abstraction
    private readonly SqlServerDatabase _database;
    private readonly SmtpEmailService _emailService;

    public CarService()
    {
        // Tightly coupled - hard to test, hard to change
        _database = new SqlServerDatabase();
        _emailService = new SmtpEmailService();
    }

    public void ProcessCar(Car car)
    {
        _database.Save(car);
        _emailService.Send("admin@example.com", "New car added", car.Make);
    }
}

public class SqlServerDatabase
{
    public void Save(Car car) => Console.WriteLine("Saving to SQL Server...");
}

public class SmtpEmailService
{
    public void Send(string to, string subject, string body) => Console.WriteLine("Sending via SMTP...");
}

// ============================================================================
// ❌ BAD PRACTICE 4: Violating Interface Segregation Principle (ISP)
// ============================================================================
// Problem: Fat interface - forces classes to implement methods they don't need
// Why it's bad: Classes must throw exceptions for methods that don't apply

// BAD: Fat interface - forces classes to implement methods they don't need
public interface IVehicle
{
    void StartEngine();
    void StopEngine();
    void Fly();        // Not all vehicles can fly!
    void Sail();       // Not all vehicles can sail!
    void Drive();      // Not all vehicles can drive!
}

public class Car2 : IVehicle
{
    public void StartEngine() => Console.WriteLine("Car engine started");
    public void StopEngine() => Console.WriteLine("Car engine stopped");
    public void Drive() => Console.WriteLine("Car driving");
    
    // BAD: Must implement methods that don't make sense
    public void Fly() => throw new NotImplementedException("Cars can't fly!");
    public void Sail() => throw new NotImplementedException("Cars can't sail!");
}

public class Airplane : IVehicle
{
    public void StartEngine() => Console.WriteLine("Airplane engine started");
    public void StopEngine() => Console.WriteLine("Airplane engine stopped");
    public void Fly() => Console.WriteLine("Airplane flying");
    
    // BAD: Must implement methods that don't make sense
    public void Drive() => throw new NotImplementedException("Airplanes don't drive!");
    public void Sail() => throw new NotImplementedException("Airplanes don't sail!");
}

// ============================================================================
// ❌ BAD PRACTICE 5: Violating Clean Architecture - Mixed Layers
// ============================================================================
// Problem: Business logic mixed with data access and UI concerns
// Why it's bad: Can't test business logic separately, hard to change database or UI

// BAD: Business logic mixed with data access and UI concerns
public class CarManager
{
    // Direct database access in business logic
    private string connectionString = "Server=localhost;Database=Cars;...";

    public void AddCar(int year, string make, decimal price)
    {
        // Business logic
        if (year < 1900) throw new Exception("Invalid year");
        if (price < 0) throw new Exception("Price cannot be negative");

        // Data access (should be in separate layer)
        // using (var connection = new SqlConnection(connectionString))
        // {
        //     // SQL code here...
        // }

        // UI concern (should be in presentation layer)
        // MessageBox.Show("Car added successfully!");
        Console.WriteLine("Car added successfully!");
    }
}

