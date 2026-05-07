using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
	class Plague : NPCEventsBlueprint
	{
		public Plague() : base("Plague", 20, 100, false, "A deadly plague has spread through the city, affecting the health of its inhabitants.") { }

	}

	class CrimeWave : NPCEventsBlueprint
	{
		public CrimeWave() : base("Crime Wave", 10, 30, true, "A surge in criminal activity has swept through the city, impacting the security of its residents.") { }
	}
}
