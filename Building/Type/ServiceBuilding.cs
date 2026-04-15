using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class ServiceBuilding : Building
	{
		public ServiceBuilding(string name, Service type,int x, int y) : base(name, x, y)
		{
			Type = BuildingType.Service;

			BuildingCost = 15000;
			MaintenanceCost = 1500;
			TaxIncome = 0;
			Capacity = 40;
			MaxHealth = 100;
			HappinessImpact = 20;
			ElectricityConsumption = 15;
			WaterConsumption = 20;
		}
	}
}
