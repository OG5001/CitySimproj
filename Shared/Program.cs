using CitySimproj;
using CitySimproj.Economy;
using CitySimproj.Shared;
using System.Runtime.CompilerServices;

namespace Buildings
{
    internal class Program
    {

        static Menu title = new Menu(new[]
{
                @"  _____ _ _         ____        _ _     _           ",
                @" / ____(_) |       |  _ \      (_) |   | |          ",
                @"| |     _| |_ _   _| |_) |_   _ _| | __| | ___ _ __ ",
                @"| |    | | __| | | |  _ <| | | | | |/ _` |/ _ \ '__|",
                @"| |____| | |_| |_| | |_) | |_| | | | (_| |  __/ |   ",
                @" \_____|_|\__|\__, |____/ \__,_|_|_|\__,_|\___|_|   ",
                @"               __/ |                               ",
                @"              |___/                                "
        });

        static string[] menu =
        {
                "Build",
                "Map",
                "Trading",
                "List",
                "Next Day",
                "Exit"
        };
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            EventManager eventManager = new EventManager();
            Treasury treasury = new Treasury();
            EconomyManager ecoManager = new EconomyManager(treasury);
            Production product = new Production(treasury);
            BuildingManager manager = new BuildingManager(treasury);
            manager.DefaultSetUp();

            bool running = true;

            while (running)
            {
                int choice = title.DrawMenu(menu);
                Console.Clear();

                switch (choice)
                {
                    case 0:
                        manager.Menu();
                        Console.Clear();    
                        break;

                    case 1:
                        BuildingManager.Draw();
                        Menu.WriteCentered("Press any key to continue...", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;

                    case 2:
                        ecoManager.Choice();
                        break;

                    case 3:
                        Console.Clear();    
                        BuildingManager.Kiiratas();
                        Console.WriteLine();
                        var allNpc = Person.NPC();
                        // list people (temp)
                        foreach (var p in allNpc)
                        {
                            Console.WriteLine(p);
                        }

                        Console.WriteLine(treasury);
                        Menu.WriteCentered("Press any key to continue...", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        break;

                    case 4:
                        eventManager.Print();
                        product.EndTurn();
                        break;

                    case 5:
                        running = false;
                        break;
                }
            }
        }
    }
}