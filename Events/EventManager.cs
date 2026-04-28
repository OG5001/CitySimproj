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
			(new Earthquake(), 2000),
			(new Tsunami(), 2000),
        };
        private readonly List<(EconomicsEventsBlueprint ecoevent, int chance)> economicsEvents = new()
        {
            (new PPM(), 2),

        };


        public void Chance()
		{
			Console.WriteLine("==== Daily Report: ====");

			foreach (var (disaster,chance) in disasters)
			{
				if (random.Next(1,chance+1) == 1)
				{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{disaster.GetType().Name} has occurred!");
					Console.ForegroundColor = ConsoleColor.White;
                    disaster.StartEffect();
				}
			}

            foreach (var (ecoevent, chance) in economicsEvents)
            {
                if (random.Next(1, chance + 1) == 1)
                {
                    ecoevent.StartEffect();
                }
            }
        }

        // Explanation
        // Creating random number + a list of disasters, with theit chances. Therefore tuples. Adding the already created disasters to the list.
		// Chance method, goes through the list of disasters, and if the random number = 1, the effect will be applied.
    }
}
