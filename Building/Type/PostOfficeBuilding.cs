using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class PostOfficeBuilding : ServiceBuilding
	{
		public PostOfficeBuilding(int x, int y) : base("Post Office",Service.PostOffice, x, y)
		{
			BuildingCost = 10000;
			MaintenanceCost = 900;
			Capacity = 60;
			TaxIncome = 0;
			HappinessImpact = 10;
			ElectricityConsumption = 15;
			WaterConsumption = 10;
		}
	}
}
