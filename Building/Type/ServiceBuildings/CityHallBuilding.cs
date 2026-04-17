using Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class CityHallBuilding : ServiceBuilding
	{
		public CityHallBuilding(int x, int y) : base("City Hall",Service.CityHall, x, y)
		{
			BuildingCost = 50000;
			MaintenanceCost = 2500;
			Capacity = 50;
			TaxIncome = 0;
			HappinessImpact = 40;
			ElectricityConsumption = 35;
			WaterConsumption = 30;
		}
	}
}
