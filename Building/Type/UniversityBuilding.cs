using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class UniversityBuilding : ServiceBuilding
	{
		public UniversityBuilding(int x, int y) : base("University",Service.University, x, y)
		{
			BuildingCost = 25000;
			MaintenanceCost = 3000;
			Capacity = 300;
			TaxIncome = 0;
			HappinessImpact = 25;
			ElectricityConsumption = 20;
			WaterConsumption = 20;
		}
	}
}
