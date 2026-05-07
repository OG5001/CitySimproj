using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Shared
{
    public class Menu(string[] title)
    {
        public string[] Title { get; private set; } = title;

        public int DrawMenu(string[] choice)
        {


            int selected = 0;

            while (true)
            {
                Console.Clear();

                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;

                int contentHeight = title.Length + choice.Length + 6;
                int startY = (windowHeight - contentHeight) / 2;

                Console.ForegroundColor = ConsoleColor.Cyan;

                for (int i = 0; i < title.Length; i++)
                {
                    int x = (windowWidth - title[i].Length) / 2;
                    Console.SetCursorPosition(x, startY + i);
                    Console.Write(title[i]);
                }

                Console.ResetColor();

                for (int i = 0; i < choice.Length; i++)
                {
                    string text = $"{choice[i]}";
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
                    selected = (selected - 1 + choice.Length) % choice.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selected = (selected + 1) % choice.Length;
                }
                else if (key == ConsoleKey.Enter)
                {
                    return selected;
                }
            }
        }

        public int SelectAmount(int min, int max)
        {
            int amount = min;

            Console.Clear();

            int windowWidth = Console.WindowWidth;
            int startY = 3;

            // Draw title only
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < title.Length; i++)
            {
                int x = (windowWidth - title[i].Length) / 2;

                Console.SetCursorPosition(x, startY + i);
                Console.Write(title[i]);
            }

            Console.ResetColor();

            int y2 = startY + title.Length + 3;

            WriteCentered("< > to change | Enter to confirm", ConsoleColor.DarkGray);

            while (true)
            {
                string text = $"< {amount} >";

                int x2 = (windowWidth - text.Length) / 2;

                // Clear only the old amount line
                Console.SetCursorPosition(0, y2);
                Console.Write(new string(' ', windowWidth));

                // Draw updated amount
                Console.SetCursorPosition(x2, y2);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(text);
                Console.ResetColor();

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.LeftArrow)
                {
                    if (amount > min)
                        amount--;
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    if (amount < max)
                        amount++;
                }
                else if (key == ConsoleKey.Enter)
                {
                    return amount;
                }
            }
        }
        public static void WriteCentered(string text, ConsoleColor color)
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
