using CitySimproj.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class EventManager
	{
		private static readonly Random random = new Random();

        private static readonly string[] titleArt =
            {
                @" _____          _____ _  __     __  _____  ______ _____   ____  _____ _______ ",
                @"|  __ \   /\   |_   _| | \ \   / / |  __ \|  ____|  __ \ / __ \|  __ \__   __|",
                @"| |  | | /  \    | | | |  \ \_/ /  | |__) | |__  | |__) | |  | | |__) | | |   ",
                @"| |  | |/ /\ \   | | | |   \   /   |  _  /|  __| |  ___/| |  | |  _  /  | |   ",
                @"| |__| / ____ \ _| |_| |____| |    | | \ \| |____| |    | |__| | | \ \  | |   ",
                @"|_____/_/    \_\_____|______|_|    |_|  \_\______|_|     \____/|_|  \_\ |_|   ",
                @"                                                                              ",
                @"                                                                              "
            };

        private readonly List<(NaturalDisasterBlueprint disaster, int chance)> disasters = new() 
		{
			(new Earthquake(), 1),
			(new Tsunami(), 1),
        };

		private readonly List<(EconomicsEventsBlueprint ecoevent, int chance)> economicsEvents = new() 
		{
			(new PowerPlantMalfunction(), 1), 
		};
		private readonly List<(NPCEventsBlueprint events, int chance)> events = new() 
		{
			(new Plague(), 1),
			(new CrimeWave(), 1)
		};

        public void Print()
		{
            Console.Clear();
            //PrintTitle();

            var occuredDisasters = RollEvents(disasters);
            var occuredEcoEvents = RollEvents(economicsEvents);
            var occuredNPCEvents = RollEvents(events);

            foreach (var d in occuredDisasters) d.StartEffect();
            foreach (var e in occuredEcoEvents) e.StartEffect();
            foreach (var n in occuredNPCEvents) n.StartEffect();

            PrintSection("NATURAL DISASTERS",occuredDisasters,
                e => e.Name,
                e => e.Description,
                ConsoleColor.Red);
            PrintSection("ECONOMIC EVENTS", occuredEcoEvents,
                e => e.Name,
                e => e.Description,
                ConsoleColor.Yellow);
            PrintSection("NPC EVENTS", occuredNPCEvents,
                e => e.Name,
                e => e.Description,
                ConsoleColor.Green);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string(' ', (Console.WindowWidth - "Press [ENTER] to continue...".Length) / 2) + "Press [ENTER] to continue...");
            Console.ResetColor();
            Console.ReadLine();

        }

        private static List<T> RollEvents<T>(List<(T item, int chance)> pool)
        {
            var result = new List<T>();
            foreach (var (item, chance) in pool)
                if (random.Next(1, chance + 1) == 1)
                    result.Add(item);
            return result;

        }
        private static void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string line in titleArt) ;
                
        }
        private static void PrintCentered(string text, ConsoleColor color = ConsoleColor.White)
        {
            int pad = (Console.WindowWidth - text.Length) / 2;
            Console.ForegroundColor = color;
            Console.WriteLine(new string(' ', pad) + text);
        }
        private static void PrintSection<T>(string title, List<T> occureds, Func<T, string> headline, Func<T, string> detail, ConsoleColor color, int width = 100)
        {
            int margin = (Console.WindowWidth - width) / 2;
            string pad = new string(' ', margin);

            void Border(char left, char right)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(pad + left + new string('-', width) + right);
                Console.ResetColor();
            }

            if (occureds.Count == 0)
            {
                Border('┌', '┐');
                Console.Write($"| No {title} occurred today.".PadRight(width + 1));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");
                Border('└', '┘');   
                return;
            }

            Border('┌', '┐');

            int titlePad = (width - title.Length) / 2;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(pad + "| " + new string(' ', titlePad - 1));
            Console.ForegroundColor = color;
            Console.Write(title);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string(' ', width - title.Length - titlePad) + "|");
            Border('├', '┤');

            foreach (var item in occureds)
            {
                string headlineText = headline(item);
                string detailText = detail(item);

                int headlinePad = (width - headlineText.Length) / 2;
                int detailPad = (width - detailText.Length) / 2;


                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(pad + "| ");
                Console.ResetColor();
                Console.Write(new string(' ', headlinePad) + headlineText + new string(' ', width - headlineText.Length - headlinePad - 1));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(pad + $"| {new string(' ', detailPad) + detailText + new string(' ', width - detailText.Length - detailPad - 1)}|");
                Console.WriteLine(pad + "|" + new string(' ', width) + "|");
                Console.ResetColor();
            }

            Border('└', '┘');
            Console.WriteLine();


        
        }
    }
    
}
