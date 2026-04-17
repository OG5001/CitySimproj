using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class PoliceStationBuilding : ServiceBuilding
	{
		public PoliceStationBuilding(int x, int y) : base("Police Station",Service.PoliceStation, x, y)
		{
			BuildingCost = 20000;
			MaintenanceCost = 1500;
			Capacity = 100;
			HappinessImpact = 10;
		}
	}
}
