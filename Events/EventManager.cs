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
            PrintTitle();

            var occuredDisasters = RollEvents(disasters);
            var occuredEcoEvents = RollEvents(economicsEvents);
            var occuredNPCEvents = RollEvents(events);

            foreach (var d in occuredDisasters) d.StartEffect();
            foreach (var e in occuredEcoEvents) e.StartEffect();
            foreach (var n in occuredNPCEvents) n.StartEffect();

            PrintSection("NATURAL DISASTERS",occuredDisasters,
                ConsoleColor.Red);
            PrintSection("ECONOMIC EVENTS", occuredEcoEvents,
                ConsoleColor.Yellow);
            PrintSection("NPC EVENTS", occuredNPCEvents,
                ConsoleColor.Green);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            PrintCentered("Press [ENTER] to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }

        private static List<IEvent> RollEvents<T>(List<(T item, int chance)> pool) 
            where T : IEvent
        {
            var result = new List<IEvent>();
            foreach (var (item, chance) in pool)
                if (random.Next(1, chance + 1) == 1)
                    result.Add(item);
            return result;

        }
        private static void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string line in titleArt)
            {
                PrintCentered(line);

            }
            Console.ResetColor();
            Console.WriteLine();
        }
        private static void PrintCentered(string text)
        {
            int pad = (Console.WindowWidth - text.Length) / 2;
            Console.WriteLine(new string(' ', Math.Max(0, pad)) + text);
        }
        private static void PrintSection<T>(string title, List<T> occureds, ConsoleColor color, int width = 100) where T : IEvent
        {
            int margin = (Console.WindowWidth - width) / 2;
            string pad = new string(' ', Math.Max(0, margin));

            int titlePad = (width - title.Length) / 2;

            void Border(char left, char right)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(pad + left + new string('-', width) + right);
                Console.ResetColor();
            }

            if (occureds.Count == 0)
            {
                string msg = $"No {title} occurred today.";
                int msgPad = (width - msg.Length) / 2;

                Border('┌', '┐');
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(pad + "|");
                Console.ResetColor();
                Console.Write(new string(' ', msgPad) + msg + new string(' ', width - msg.Length - msgPad));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");
                Border('└', '┘');
                return;
            }   

            string Center(string text)
            {
                int left = (width - text.Length) / 2;
                int right = width - text.Length - left;
                return new string(' ', left) + text + new string(' ', right);
            }

            Border('┌', '┐');

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(pad + "|");
            Console.ForegroundColor = color;
            Console.Write(Center(title));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("|");

            Border('├', '┤');

            foreach (var item in occureds)
            {
                string headlineText = item.Name;
                string detailText = item.Description;

                int headlinePad = (width - headlineText.Length) / 2;
                int detailPad = (width - detailText.Length) / 2;


                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(pad + "|");
                Console.ResetColor();
                Console.Write(Center(headlineText));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");


                Console.Write(pad + "|" + Center(detailText));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");

                Console.WriteLine(pad + "|" + new string(' ', width) + "|");
                Console.ResetColor();
            }

            Border('└', '┘');
            Console.WriteLine();


        
        }
    }
    
}
