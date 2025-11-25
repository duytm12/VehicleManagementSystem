using App.Enums;
namespace App.Helpers;

public static class InputHelpers
{
    public static MenuChoice GetChoice()
    {
        while (true)
        {
            Console.Write("Please enter your selection: ");
            string? input = Console.ReadLine()?.Trim() ?? string.Empty;
            if (input == string.Empty)
            {
                Console.WriteLine("Input cannot be empty");
                continue;
            }

            if (!int.TryParse(input, out int val))
            {
                Console.WriteLine("Invalid Input. Please try again");
                continue;
            }

            if (Enum.IsDefined(typeof(MenuChoice), val)) return (MenuChoice)val;

            Console.WriteLine("Invalid input. Please try again");
        }
    }
}

