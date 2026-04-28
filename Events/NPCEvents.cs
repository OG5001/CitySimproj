using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
	class Plague : NPCEventsBlueprint
	{
		public Plague() : base("Plague", 20, 100, false) { }

	}

	class CrimeWave : NPCEventsBlueprint
	{
		public CrimeWave() : base("Crime Wave", 10, 30, true) { }
	}
}
