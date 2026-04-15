using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class UtilityBuilding : Building
	{
		public UtilityBuilding(string name,Utility type, int x, int y) : base(name, x, y)
		{
			Type = BuildingType.Utility;
			MaxHealth = 100;
			DecideValues(type);
		}

		public void DecideValues(Utility type)
		{
			switch (type)
			{
				case Utility.WaterTower:
					BuildingCost = 5000;
					MaintenanceCost = 750;
					TaxIncome = 100;
					Capacity = 20;
					HappinessImpact = 10;
					ElectricityConsumption = 20;
					WaterConsumption = 0;
					break;
				case Utility.WaterTreatmentPlant:
					BuildingCost = 15000;
					MaintenanceCost = 1500;
					TaxIncome = 250;
					Capacity = 50;
					HappinessImpact = -5;
					ElectricityConsumption = 60;
					WaterConsumption = -100;
					break;
				case Utility.SolarPlant:
					BuildingCost = 10000;
					MaintenanceCost = 2000;
					TaxIncome = 250;
					Capacity = 50;
					HappinessImpact = -5;
					ElectricityConsumption = -75;
					WaterConsumption = 20;
					break;
				case Utility.SewagePlant:
					BuildingCost = 15000;
					MaintenanceCost = 2500;
					TaxIncome = 250;
					Capacity = 100;
					HappinessImpact = 40;
					ElectricityConsumption = 40;
					WaterConsumption = 50;
					break;
				case Utility.GasStation:
					BuildingCost = 2000;
					MaintenanceCost = 500;
					TaxIncome = 300;
					Capacity = 15;
					HappinessImpact = 10;
					ElectricityConsumption = 20;
					WaterConsumption = 30;
					break;
				case Utility.PowerSubstation:
					BuildingCost = 10000;
					MaintenanceCost = 2500;
					TaxIncome = 250;
					Capacity = 75;
					HappinessImpact = 10;
					ElectricityConsumption = -40;
					WaterConsumption = 50;
					break;
				case Utility.Landfill:
					BuildingCost = 2000;
					MaintenanceCost = 500;
					TaxIncome = 100;
					Capacity = 40;
					HappinessImpact = -50;
					ElectricityConsumption = 20;
					WaterConsumption = 20;
					break;
				case Utility.WindTurbine:
					BuildingCost = 5000;
					MaintenanceCost = 500;
					TaxIncome = 250;
					Capacity = 10;
					HappinessImpact = 0;
					ElectricityConsumption = -50;
					WaterConsumption = 20;
					break;
				case Utility.WasteProcessing:
					BuildingCost = 15000;
					MaintenanceCost = 2000;
					TaxIncome = 250;
					Capacity = 100;
					HappinessImpact = 30;
					ElectricityConsumption = 40;
					WaterConsumption = 50;
					break;


			}
		}
		public override string ToString()
		{
			return $"Building Cost: {BuildingCost}, Maintenance Cost: {MaintenanceCost}, Tax Income: {TaxIncome}, Capacity: {Capacity}, Happiness Impact: {HappinessImpact}, Electricity Consumption: {ElectricityConsumption}, Water Consumption: {WaterConsumption} ";
		}
	
	}
}
