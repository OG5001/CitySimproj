using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemenykezelesOOP
{
	internal class EventManager
	{

		// List of active Events
		private List<Event> activeEvents = new List<Event>();




		// Starting the Events 
		public void StartEvent(NPCEvents newNPC)
		{
			activeEvents.Add(newNPC);
			newNPC.ApplyEffect();
		}
		public void StartEvent(EconomicEvents newEconomic)
		{
			activeEvents.Add(newEconomic);
			newEconomic.ApplyEffect();
		}
		public void StartEvent(BuildingEvents newBuilding)
		{
			activeEvents.Add(newBuilding);
			newBuilding.ApplyEffect();
		}


		// Ending the Events
		public void EndEvent(NPCEvents newNPC )
		{
			activeEvents.Remove(newNPC);
			newNPC.RemoveEffect();
		}
		public void EndEvent(EconomicEvents newEconomic)
		{
			activeEvents.Remove(newEconomic);
			newEconomic.RemoveEffect();
		}
		public void EndEvent(BuildingEvents newBuilding)
		{
			activeEvents.Remove(newBuilding);
			newBuilding.RemoveEffect();
		}
	}
}
