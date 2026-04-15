using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class IndustrialBuilding : Building
	{
		public IndustrialBuilding(string name,Industrial type ,int x, int y) : base(name, x, y)
		{
			Type = BuildingType.Industrial;
			MaxHealth = 100;
			DecideValues(type);
		}

		public void DecideValues(Industrial type)
		{
			switch (type)
			{
				case Industrial.Factory:
					BuildingCost = 10000;
					MaintenanceCost = 1000;
					TaxIncome = 2000;
					Capacity = 50;
					HappinessImpact = -20;
					ElectricityConsumption = 30;
					WaterConsumption = 30;
					break;
				case Industrial.PowerPlant:
					BuildingCost = 10000;
					MaintenanceCost = 1000;
					TaxIncome = 500;
					Capacity = 100;
					HappinessImpact = -20;
					ElectricityConsumption = -40;
					WaterConsumption = 50;
					break;
				case Industrial.Warehouse:
					BuildingCost = 10000;
					MaintenanceCost = 1500;
					TaxIncome = 1000;
					Capacity = 150;
					HappinessImpact = -20;
					ElectricityConsumption = 50;
					WaterConsumption = 20;
					break;
				case Industrial.Workshop:
					BuildingCost = 5000;
					MaintenanceCost = 500;
					TaxIncome = 750;
					Capacity = 20;
					HappinessImpact = -20;
					ElectricityConsumption = 20;
					WaterConsumption = 15;
					break;
				case Industrial.OilRefinery:
					BuildingCost = 10000;
					MaintenanceCost = 1000;
					TaxIncome = 750;
					Capacity = 100;
					HappinessImpact = -20;
					ElectricityConsumption = 40;
					WaterConsumption = 50;
					break;
				case Industrial.LogisticsCenter:
					BuildingCost = 10000;
					MaintenanceCost = 1500;
					TaxIncome = 1000;
					Capacity = 100;
					HappinessImpact = -20;
					ElectricityConsumption = 50;
					WaterConsumption = 30;
					break;
				case Industrial.SteelMill:
					BuildingCost = 10000;
					MaintenanceCost = 1000;
					TaxIncome = 500;
					Capacity = 75;
					HappinessImpact = -20;
					ElectricityConsumption = 40;
					WaterConsumption = 20;
					break;
				case Industrial.RecyclingPlant:
					BuildingCost = 5000;
					MaintenanceCost = 500;
					TaxIncome = 400;
					Capacity = 50;
					HappinessImpact = 15;
					ElectricityConsumption = 30;
					WaterConsumption = 70;
					break;

			}
		}
		public override string ToString()
		{
			return $"Building Cost: {BuildingCost}, Maintenance Cost: {MaintenanceCost}, Tax Income: {TaxIncome}, Capacity: {Capacity}, Happiness Impact: {HappinessImpact}, Electricity Consumption: {ElectricityConsumption}, Water Consumption: {WaterConsumption} ";
		}
	}
}
