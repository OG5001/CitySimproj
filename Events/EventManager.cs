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
			int randomChanceEarthquake = random.Next(1,5001);
			if (randomChanceEarthquake == 1)
			{
				Earthquake earthquake = new Earthquake();
				earthquake.StartEffect();
			}

            int randomChanceTsunami = random.Next(2, 5001);
            if (randomChanceTsunami == 2)
            {
                Tsunami tsunami = new Tsunami();
                tsunami.StartEffect();
            }
        }
	}
}
