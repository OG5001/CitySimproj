using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class CourtBuilding : ServiceBuilding
	{
		public CourtBuilding(int x, int y) : base("Court",Service.Court, x, y)
		{
			BuildingCost = 25000;
			MaintenanceCost = 2000;
			Capacity = 200;
			HappinessImpact = 10;
			ElectricityConsumption = 40;
			WaterConsumption = 30;
		}
	}
}
