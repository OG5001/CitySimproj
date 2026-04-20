using Buildings;
using System.Globalization;

namespace Varos_Gazdasag; 

internal class Program
{
    static void Main(string[] args)
    {
        Electricity e1 = new Electricity(20, 10, 8);
        Water w1 = new Water(40, 10, 4);
        int cmd;
        
        while (true)
        {
            Console.WriteLine("--- NEW TURN ---");
            Console.WriteLine(e1);
            Console.WriteLine(w1);

            Console.WriteLine("\n--- Production ---");
            Console.WriteLine($"Electricity: {e1.Produce()}");
            Console.WriteLine($"Water: {w1.Produce()}");
            Console.WriteLine("\n--- Consumption ---");
            Console.WriteLine($"Electricity: {e1.Consume()}");
            Console.WriteLine($"Water: {w1.Consume()}");

            Console.WriteLine("\nChange electric generator amount:");
            cmd = int.Parse(Console.ReadLine()!);
            e1.Amount = cmd;
            Console.WriteLine("\nChange water silo amount:");
            cmd = int.Parse(Console.ReadLine()!);
            w1.Amount = cmd;

            Console.WriteLine("\nNext turn...");
            Console.ReadLine();
        }
        var buildings = BuildingManager.GetAllBuildings();
    }
}