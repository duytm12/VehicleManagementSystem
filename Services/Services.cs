using System.Security.AccessControl;
using App.Enums;
using App.Models;
using App.Models;
using Microsoft.VisualBasic;

namespace App.Services;

/// <summary>
/// Example service class. Replace with your own services.
/// Services contain business logic and are called from Application.cs
/// </summary>
public class Services
{
    public static void A(Cars car)
    {
        car = new Cars(2020, "Acura", "Integra", 20000, true);

        var car1 = new Cars(2020, "Mercedes", "C300", 30000, true);
        
    }

}

