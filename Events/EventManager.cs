using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class EventManager
	{
		private static readonly Random random = new Random();
		private readonly List<(NaturalDisasterBlueprint disaster, int chance)> disasters = new()
		{
			(new Earthquake(), 5000)
		};

		public void Chance()
		{
			foreach (var (disaster,chance) in disasters)
			{
				if (random.Next(1,chance+1) == 1)
				{
					disaster.StartEffect();
				}
			}
		}
	}
}
