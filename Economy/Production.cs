using System.Globalization;

namespace CitySimproj; 

internal class Production
{
    static void Produce()
    {
        int cmd;
        
        while (true)
        {
            Console.WriteLine("--- NEW TURN ---");


            Console.WriteLine("\n--- Production ---");

            Console.WriteLine("\n--- Consumption ---");


            Console.WriteLine("\nChange electric generator amount:");
            cmd = int.Parse(Console.ReadLine()!);

            Console.WriteLine("\nChange water silo amount:");
            cmd = int.Parse(Console.ReadLine()!);


            Console.WriteLine("\nNext turn...");
            Console.ReadLine();
        }
    }
}