using CitySimproj;

namespace Buildings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            BuildingManager manager = new BuildingManager();
            EventManager eventManager = new EventManager();
            Treasury treasury = new Treasury();
            EconomyManager ecoManager = new EconomyManager(treasury);
            Production product = new Production();
            manager.DefaultSetUp();

            bool running = true;

            while (running)
            {
                int choice = DrawMenu();

                Console.Clear();

                switch (choice)
                {
                    case 0:
                        manager.Menu();
                        break;

                    case 1:
                        BuildingManager.Draw();
                        break;

                    case 2:
                        ecoManager.Choice();
                        break;

                    case 3:
                        BuildingManager.Kiiratas();
                        break;

                    case 4:
                        eventManager.Chance();
                        product.Calculate();
                        Console.WriteLine(treasury);
                        break;

                    case 5:
                        running = false;
                        break;
                }

                if (running)
                {
                    WriteCentered("Press any key to continue...", ConsoleColor.DarkGray);
                    Console.ReadKey(true);
                }
            }
        }

        static int DrawMenu()
        {
            string[] title =
            {
                @"  _____ _ _         ____        _ _     _           ",
                @" / ____(_) |       |  _ \      (_) |   | |          ",
                @"| |     _| |_ _   _| |_) |_   _ _| | __| | ___ _ __ ",
                @"| |    | | __| | | |  _ <| | | | | |/ _` |/ _ \ '__|",
                @"| |____| | |_| |_| | |_) | |_| | | | (_| |  __/ |   ",
                @" \_____|_|\__|\__, |____/ \__,_|_|_|\__,_|\___|_|   ",
                @"               __/ |                               ",
                @"              |___/                                "
            };

            string[] menu =
            {
                "Build",
                "Map",
                "Trading",
                "List buildings",
                "Next Day",
                "Exit"
            };

            int selected = 0;

            while (true)
            {
                Console.Clear();

                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;

                int contentHeight = title.Length + menu.Length + 6;
                int startY = (windowHeight - contentHeight) / 2;

                Console.ForegroundColor = ConsoleColor.Cyan;

                for (int i = 0; i < title.Length; i++)
                {
                    int x = (windowWidth - title[i].Length) / 2;
                    Console.SetCursorPosition(x, startY + i);
                    Console.Write(title[i]);
                }

                Console.ResetColor();

                for (int i = 0; i < menu.Length; i++)
                {
                    string text = $"{menu[i]}";
                    int x = (windowWidth - text.Length) / 2;
                    int y = startY + title.Length + 2 + i;

                    Console.SetCursorPosition(x, y);

                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(text);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(text);
                        Console.ResetColor();
                    }
                }


                WriteCentered("Use up and down arrows and Enter", ConsoleColor.DarkGray);


                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selected = (selected - 1 + menu.Length) % menu.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selected = (selected + 1) % menu.Length;
                }
                else if (key == ConsoleKey.Enter)
                {
                    return selected;
                }
            }
        }

        static void WriteCentered(string text, ConsoleColor color)
        {
            int x = (Console.WindowWidth - text.Length) / 2;
            int y = Console.WindowHeight - 2;

            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}