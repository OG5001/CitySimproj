using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class SchoolBuilding : ServiceBuilding
	{
		public SchoolBuilding(int x, int y) : base("School",Service.School, x, y)
		{
			BuildingCost = 35000;
			MaintenanceCost = 1500;
			Capacity = 400;
			TaxIncome = 0;
			HappinessImpact = 50;
			ElectricityConsumption = 45;
			WaterConsumption = 30;
		}
	}
}
