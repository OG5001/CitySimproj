using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class EventManager
	{
		public void Chance()
		{
			Random random = new Random();
			
			for (int i = 0; i < 10; i++)
			{
				int chanceToHappen = random.Next(0, 100);
				// Happening the event
				if (chanceToHappen < 5) 
				{
					Earthquake earthquake = new Earthquake();
					earthquake.StartEffect();
					break;
				}
			}
		}
	}
}
