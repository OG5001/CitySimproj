using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class UszodaBuilding : ServiceBuilding
	{
		public UszodaBuilding(int x, int y) : base("Uszoda",Service.Uszoda, x, y)
		{
			BuildingCost = 36000;
			MaintenanceCost = 3000;
			Capacity = 120;
			HappinessImpact = 20;
			ElectricityConsumption = 35;
			WaterConsumption = 80;
		}
	}
}
