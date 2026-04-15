using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class Hospital : ServiceBuilding
	{
		public Hospital(int x, int y) : base("Hospital",Service.Library, x, y)
		{
			BuildingCost = 50000;
			MaintenanceCost = 4000;
			Capacity = 250;
			TaxIncome = 0;
			HappinessImpact = 40;
			ElectricityConsumption = 60;
			WaterConsumption = 50;
		}
	}
}
