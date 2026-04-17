using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class FireStationBuilding : ServiceBuilding
	{
		public FireStationBuilding(int x, int y) : base("Fire Station",Service.FireStation, x, y)
		{
			BuildingCost = 30000;
			MaintenanceCost = 3000;
			Capacity = 80;
			TaxIncome = 0;
			HappinessImpact = 35;
			ElectricityConsumption = 45;
			WaterConsumption = 60;
		}
	}
}
