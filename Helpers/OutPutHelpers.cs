namespace App.Helpers;

public static class OutPutHelpers
{
    public static void PrintLine(char c, int i)
    {
        Console.WriteLine(new string(c, i));
    }
    public static void PrintStartMenu()
    {
        PrintLine('*', 80);
        Console.WriteLine("What do you want to do today?");
        PrintLine('-', 80);
        Console.WriteLine("1 - Add vehicles");
        Console.WriteLine("2 - List vehicles");
        Console.WriteLine("3 - Get vehicle details");
        Console.WriteLine("4 - Update vehicles");
        Console.WriteLine("5 - Remove vehicles");
        Console.WriteLine("6 - Save vehicles to file");
        Console.WriteLine("7 - Load vehicles from file");
        Console.WriteLine("0 - Exit");
        PrintLine('-', 80);
        // Console.WriteLine("Press any key to continue");
        // Console.ReadKey();
    }
    
}

