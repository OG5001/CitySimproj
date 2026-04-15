using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class LibraryBuilding : ServiceBuilding
	{
		public LibraryBuilding(int x, int y) : base("Library",Service.Library, x, y)
		{
			BuildingCost = 15000;
			MaintenanceCost = 1000;
			Capacity = 75;
			TaxIncome = 0;
			HappinessImpact = 40;
			ElectricityConsumption = 25;
			WaterConsumption = 10;
		}
	}
}
