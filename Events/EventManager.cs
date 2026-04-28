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
		private readonly List<(NaturalDisasterBlueprint disaster, int chance)> disasters = new() // Natural list
		{
			(new Earthquake(), 2000),
			(new Tsunami(), 2000),
        };

		private readonly List<(EconomicsEventsBlueprint ecoevent, int chance)> economicsEvents = new() // Economics list
		{
			(new PPM(), 2), // Power Plant Malfunctioning
		};
		private readonly List<(NPCEventsBlueprint events, int chance)> events = new() // NPC list
		{
			(new Plague(), 2),
			(new CrimeWave(), 2)
		};

        public void Chance()
		{
			Console.WriteLine("==== Daily Report: ====");

			foreach (var (disaster,chance) in disasters) // Chance for disasters
            {
				if (random.Next(1,chance+1) == 1)
				{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{disaster.GetType().Name} has occurred!");
					Console.ForegroundColor = ConsoleColor.White;
                    disaster.StartEffect();
				}
			}

            foreach (var (ecoevent, chance) in economicsEvents) // Chance for economics events
            {
                if (random.Next(1, chance + 1) == 1)
                {
                    ecoevent.StartEffect();
                }
            }

            foreach (var (events, chance) in events) // Chance for NPC events
            {
                if (random.Next(1, chance + 1) == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{events.GetType().Name} has occurred!");
                    Console.ForegroundColor = ConsoleColor.White;
                    events.StartEffect();
                }
            }
        }
    }

        // Explanation
        // Creating random number + a list of disasters, with theit chances. Therefore tuples. Adding the already created disasters to the list.
		// Chance method, goes through the list of disasters, and if the random number = 1, the effect will be applied.
    
}
