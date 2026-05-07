using CitySimproj.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class EventManager
	{
		private static readonly Random random = new Random();

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
           var occuredDisasters = new List<NaturalDisasterBlueprint>();
           var occuredEcoEvents = new List<EconomicsEventsBlueprint>();
           var occuredNPCEvents = new List<NPCEventsBlueprint>();


            foreach (var (disaster,chance) in disasters) 
            {
				if (random.Next(1,chance+1) == 1)
				{
                    disaster.StartEffect();
                    occuredDisasters.Add(disaster);
                }
			}

            foreach (var (ecoevent, chance) in economicsEvents) 
            {
                if (random.Next(1, chance + 1) == 1)
                {
                    ecoevent.StartEffect();
                    occuredEcoEvents.Add(ecoevent);
                }
            }

            foreach (var (events, chance) in events) 
            {
                if (random.Next(1, chance + 1) == 1)
                {
                    events.StartEffect();
                    occuredNPCEvents.Add(events);
                }
            }

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
            Console.WriteLine("\n  Press [ENTER] to continue...");
            Console.ResetColor();
            Console.ReadLine();

        }
        private static void PrintSection<T>(string title, List<T> occureds, Func<T, string> headline, Func<T, string> detail, ConsoleColor color, int width = 80)
        {
            if (occureds.Count == 0)
            {
                Border('┌', '┐');
                Console.Write($"| No {title} occurred today.".PadRight(width + 1));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");
                Border('└', '┘');   
                return;
            }
            
            void Border(char left, char right)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(left + new string('-', width) + right);
                Console.ResetColor();
            }

            Border('┌', '┐');

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("| ");
            Console.ForegroundColor = color;
            Console.Write(title);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string(' ', width - title.Length - 1) + "|");

            Border('├', '┤');

            foreach (var item in occureds)
            {
                string headlineText = headline(item);
                string detailText = detail(item);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("| ");
                Console.ResetColor();
                Console.Write(headlineText.PadRight(width - 1));
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"| {detailText.PadRight(width - 1)}|");
                Console.WriteLine("|" + new string(' ', width) + "|");
                Console.ResetColor();
            }

            Border('└', '┘');
            Console.WriteLine();
        }
    }
    
}
