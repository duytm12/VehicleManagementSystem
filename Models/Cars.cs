using Microsoft.VisualBasic;

namespace App.Models;

// ============================================================================
// COMMENTED OUT - Original implementation
// ============================================================================
/*
/// <summary>
/// Example model class. Replace with your own models.
/// Models should contain only data properties, no business logic.
/// </summary>
public class Cars(int year, string make, string model, decimal price, bool? isAutomatic)
{
    public int Year { get; set; } = year;
    public string? Make { get; set; } = make;
    public string? Model { get; set; } = model;
    public decimal Price { get; set; } = price;
    public bool? IsAutomatic { get; set; } = isAutomatic;
}
*/

// ============================================================================
// ALL WAYS TO CREATE A CLASS IN C#
// ============================================================================

// 1. BASIC CLASS - Parameterless constructor (default)
// Usage: var car = new Cars { Year = 2020, Make = "Toyota" };
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public int Year { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public decimal Price { get; set; }
    public bool? IsAutomatic { get; set; }
}
*/

// 2. CLASS WITH PARAMETERIZED CONSTRUCTOR
// Usage: var car = new Cars(2020, "Toyota", "Corolla", 25000, true);
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public Cars(int year, string make, string model, decimal price, bool isAutomatic)
    {
        Year = year;
        Make = make;
        Model = model;
        Price = price;
        IsAutomatic = isAutomatic;
    }

    public int Year { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public decimal Price { get; set; }
    public bool IsAutomatic { get; set; }
}
*/

// 3. CLASS WITH BOTH PARAMETERLESS AND PARAMETERIZED CONSTRUCTORS
// Usage: var car1 = new Cars();
//        var car2 = new Cars(2020, "Toyota", "Corolla", 25000, true);
// ----------------------------------------------------------------------------
/*
public class Cars
{
    // Parameterless constructor
    public Cars() { }

    // Parameterized constructor
    public Cars(int year, string make, string model, decimal price, bool isAutomatic)
    {
        Year = year;
        Make = make;
        Model = model;
        Price = price;
        IsAutomatic = isAutomatic;
    }

    public int Year { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public decimal Price { get; set; }
    public bool IsAutomatic { get; set; }
}
*/

// 4. PRIMARY CONSTRUCTOR (C# 12+) - Most concise
// Usage: var car = new Cars(2020, "Toyota", "Corolla", 25000, true);
// ----------------------------------------------------------------------------
/*
public class Cars(int year, string make, string model, decimal price, bool isAutomatic)
{
    public int Year { get; set; } = year;
    public string? Make { get; set; } = make;
    public string? Model { get; set; } = model;
    public decimal Price { get; set; } = price;
    public bool IsAutomatic { get; set; } = isAutomatic;
}
*/

// 5. REQUIRED PROPERTIES (C# 11+) - Must use object initializer
// Usage: var car = new Cars { Year = 2020, Make = "Toyota", Model = "Corolla", Price = 25000, IsAutomatic = true };
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public required int Year { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public required decimal Price { get; set; }
    public required bool IsAutomatic { get; set; }
}
*/

// 6. INIT-ONLY PROPERTIES (C# 9+) - Can only be set during initialization
// Usage: var car = new Cars { Year = 2020, Make = "Toyota" };
//        car.Year = 2021; // ERROR - cannot change after initialization
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public int Year { get; init; }
    public string? Make { get; init; }
    public string? Model { get; init; }
    public decimal Price { get; init; }
    public bool IsAutomatic { get; init; }
}
*/

// 7. READ-ONLY PROPERTIES - Can only be set in constructor
// Usage: var car = new Cars(2020, "Toyota", "Corolla", 25000, true);
//        car.Year = 2021; // ERROR - read-only
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public Cars(int year, string make, string model, decimal price, bool isAutomatic)
    {
        Year = year;
        Make = make;
        Model = model;
        Price = price;
        IsAutomatic = isAutomatic;
    }

    public int Year { get; }
    public string Make { get; }
    public string Model { get; }
    public decimal Price { get; }
    public bool IsAutomatic { get; }
}
*/

// 8. PROPERTIES WITH DEFAULT VALUES
// Usage: var car = new Cars(); // Uses defaults
//        var car2 = new Cars { Year = 2020 }; // Override some defaults
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public int Year { get; set; } = 2024;
    public string Make { get; set; } = "Unknown";
    public string Model { get; set; } = "Unknown";
    public decimal Price { get; set; } = 0;
    public bool IsAutomatic { get; set; } = false;
}
*/

// 9. PROPERTIES WITH PRIVATE SETTERS - Public read, private write
// Usage: var car = new Cars();
//        car.Year = 2020; // ERROR - setter is private
//        car.SetYear(2020); // OK - uses method
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public int Year { get; private set; }
    public string? Make { get; private set; }
    public string? Model { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAutomatic { get; private set; }

    public void SetYear(int year) => Year = year;
    public void SetMake(string make) => Make = make;
    public void SetModel(string model) => Model = model;
    public void SetPrice(decimal price) => Price = price;
    public void SetIsAutomatic(bool isAutomatic) => IsAutomatic = isAutomatic;
}
*/

// 10. RECORD TYPE (C# 9+) - Immutable by default, value-based equality
// Usage: var car = new Cars(2020, "Toyota", "Corolla", 25000, true);
//        var car2 = car with { Year = 2021 }; // Creates new instance with changed value
// ----------------------------------------------------------------------------
/*
public record Cars
{
    public int Year { get; init; }
    public string Make { get; init; }
    public string Model { get; init; }
    public decimal Price { get; init; }
    public bool IsAutomatic { get; init; }

    public Cars(int year, string make, string model, decimal price, bool isAutomatic)
    {
        Year = year;
        Make = make;
        Model = model;
        Price = price;
        IsAutomatic = isAutomatic;
    }
}
*/

// 11. RECORD WITH PRIMARY CONSTRUCTOR (C# 9+)
// Usage: var car = new Cars(2020, "Toyota", "Corolla", 25000, true);
// ----------------------------------------------------------------------------
/*
public record Cars(int Year, string Make, string Model, decimal Price, bool IsAutomatic);
*/

// 12. CLASS WITH VALIDATION IN CONSTRUCTOR
// Usage: var car = new Cars(2020, "Toyota", "Corolla", 25000, true);
//        var car2 = new Cars(-1, "", "", -100, true); // Throws exception
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public Cars(int year, string make, string model, decimal price, bool isAutomatic)
    {
        if (year < 1886) throw new ArgumentException("Year must be >= 1886");
        if (string.IsNullOrWhiteSpace(make)) throw new ArgumentException("Make cannot be empty");
        if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model cannot be empty");
        if (price < 0) throw new ArgumentException("Price cannot be negative");

        Year = year;
        Make = make;
        Model = model;
        Price = price;
        IsAutomatic = isAutomatic;
    }

    public int Year { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public bool IsAutomatic { get; set; }
}
*/

// 13. CLASS WITH OPTIONAL PARAMETERS IN CONSTRUCTOR
// Usage: var car1 = new Cars(2020, "Toyota", "Corolla");
//        var car2 = new Cars(2020, "Toyota", "Corolla", 25000);
//        var car3 = new Cars(2020, "Toyota", "Corolla", 25000, true);
// ----------------------------------------------------------------------------
/*
public class Cars
{
    public Cars(int year, string make, string model, decimal price = 0, bool isAutomatic = false)
    {
        Year = year;
        Make = make;
        Model = model;
        Price = price;
        IsAutomatic = isAutomatic;
    }

    public int Year { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }
    public bool IsAutomatic { get; set; }
}
*/

// 14. STATIC CLASS - Cannot be instantiated, only contains static members
// Usage: Cars.DisplayInfo(); // OK
//        var car = new Cars(); // ERROR - cannot instantiate
// ----------------------------------------------------------------------------
/*
public static class Cars
{
    public static void DisplayInfo()
    {
        Console.WriteLine("This is a static class about cars");
    }

    public static int CalculateAge(int year) => DateTime.Now.Year - year;
}
*/

// 15. ABSTRACT CLASS - Cannot be instantiated directly, must be inherited
// Usage: var car = new Cars(); // ERROR
//        var sedan = new Sedan(); // OK if Sedan inherits Cars
// ----------------------------------------------------------------------------
/*
public abstract class Cars
{
    public int Year { get; set; }
    public string? Make { get; set; }
    public string? Model { get; set; }
    public decimal Price { get; set; }
    public bool IsAutomatic { get; set; }

    public abstract void StartEngine(); // Must be implemented by derived classes
}
*/

// ============================================================================
// ACTIVE IMPLEMENTATION - Uncomment ONE of the above to use
// ============================================================================

// Currently using: Primary Constructor (Option 4)
public class Cars(int year, string make, string model, decimal price, bool? isAutomatic)
{
    public int Year { get; set; } = year;
    public string? Make { get; set; } = make;
    public string? Model { get; set; } = model;
    public decimal Price { get; set; } = price;
    public bool? IsAutomatic { get; set; } = isAutomatic;
}
