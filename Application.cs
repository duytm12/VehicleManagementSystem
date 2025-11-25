using App.Services;
using App.Enums;
using IH = App.Helpers.InputHelpers;
using OH = App.Helpers.OutPutHelpers;


namespace App;

/// <summary>
/// Main application class that orchestrates the application flow.
/// This is where you coordinate user interaction, call services, and manage the application lifecycle.
/// </summary>
public class Application
{
    public void Run()
    {
        Console.WriteLine("Welcome to the Vehicle Management System");
        
        while (true)
        {
            OH.PrintStartMenu();
            MenuChoice choice = IH.GetChoice();
            switch (choice)
            {
                case MenuChoice.Exit:
                    Console.WriteLine("Thank you for using the Car Management System.");
                    return;
                case MenuChoice.AddVehicle:
                    HandleAddVehicle();
                    break;
                case MenuChoice.ListVehicle:
                    HandleListVehicle();
                    break;
                case MenuChoice.GetVehicleDetail:
                    HandleGetVehicleDetail();
                    break;
                case MenuChoice.UpdateVehicle:
                    HandleUpdateVehicle();
                    break;
                case MenuChoice.RemoveVehicle:
                    HandleRemoveVehicle();
                    break;
                case MenuChoice.WriteVehicleToFile:
                    HandleWriteVehicleToFile();
                    break;
                case MenuChoice.ReadVehicleFromFile:
                    HandleReadVehicleFromFile();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again");
                    break;
            }
        }
    }

    private void HandleAddVehicle()
    {
        Console.WriteLine("feature 1 is coming");
    }

    private void HandleListVehicle()
    {
        Console.WriteLine("feature 2 is coming");
    }

    private void HandleGetVehicleDetail()
    {
        Console.WriteLine("feature 3 is coming");
    }

    private void HandleUpdateVehicle()
    {
        Console.WriteLine("feature 4 is coming");
    }

    private void HandleRemoveVehicle()
    {
        Console.WriteLine("feature 5 is coming");
    }

    private void HandleWriteVehicleToFile()
    {
        Console.WriteLine("feature 6 is coming");
    }
    
    private void HandleReadVehicleFromFile()
    {
        Console.WriteLine("feature 7 is coming");
    }
}


