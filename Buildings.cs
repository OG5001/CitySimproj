namespace Buildings
{
	public abstract class Building
	{
		// ==== Private adattagok ====
		private static List<Building> buildings = new List<Building>();
		private BuildingType type;
		private string name;

		private int x;
		private int y;

		private decimal buildingCost;
		private decimal maintenanceCost;
		private int taxIncome;

		private int maxHealth;
		private int currentHealth;

		private bool isPowered;
		private bool isConnectedToWater;

		private int capacity;
		private int currentOccupancy;

		private int happinessImpact;

		private int electricityConsumption;
		private int waterConsumption;

		// ==== Public property-k ====

		public BuildingType Type { get => type; protected set => type = value; }
		public string Name { get => name; set => name = value; }
		public int X { get => x; set => x = value; }
		public int Y { get => y; set => y = value; }
		public decimal BuildingCost { get => buildingCost; protected set => buildingCost = value; }
		public decimal MaintenanceCost { get => maintenanceCost; protected set => maintenanceCost = value; }
		public int TaxIncome { get => taxIncome; protected set => taxIncome = value; }
		public int MaxHealth { get => maxHealth; protected set => maxHealth = value; }
		public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
		public bool IsPowered { get => isPowered; set => isPowered = value; }
		public bool IsConnectedToWater { get => isConnectedToWater; set => isConnectedToWater = value; }
		public int Capacity { get => capacity; protected set => capacity = value; }
		public int CurrentOccupancy { get => currentOccupancy; set => currentOccupancy = value; }
		public int HappinessImpact { get => happinessImpact; protected set => happinessImpact = value; }
		public int ElectricityConsumption { get => electricityConsumption; protected set => electricityConsumption = value; }
		public int WaterConsumption { get => waterConsumption; protected set => waterConsumption = value; }

		// ==== Konstruktor ====
		protected Building(string name, int x, int y)
		{
			this.Name = name;
			this.X = x;
			this.Y = y;
			this.CurrentHealth = MaxHealth;
		}

		// ==== Példa virtuális metódus ====
		public virtual decimal CalculateNetIncome()
		{
			return TaxIncome - MaintenanceCost;
		}


		public static bool Add(Building building)
		{
			// Ha már van ugyanazon a koordinátán épület → nem adjuk hozzá
			foreach (var b in buildings)
			{
				if (b.X == building.X && b.Y == building.Y)
				{
					return false;
				}
			}

			buildings.Add(building);
			return true;
		}

		// ==== Remove metódus ====
		public static bool Remove(Building building)
		{
			if (building == null)
				return false;

			for (int i = 0; i < buildings.Count; i++)
			{
				if (buildings[i].X == building.X && buildings[i].Y == building.Y)
				{
					buildings.RemoveAt(i);
					return true;
				}
			}

			return false;
		}
		/*
		public static void Draw()
		{
			// Meghatározzuk a pálya méretét
			int maxX = 0;
			int maxY = 0;

			for (int i = 0; i < buildings.Count; i++)
			{
				if (buildings[i].X > maxX)
					maxX = buildings[i].X;

				if (buildings[i].Y > maxY)
					maxY = buildings[i].Y;
			}

			// Mátrix létrehozása
			Building[,] matrix = new Building[maxX + 1, maxY + 1];

			// Feltöltés
			for (int i = 0; i < buildings.Count; i++)
			{
				Building b = buildings[i];
				matrix[b.X, b.Y] = b;
			}

			// Kirajzolás
			for (int y = 1; y <= maxY + 1; y++)
			{

				for (int x = 1; x <= maxX + 1; x++)
				{
					if (matrix[x - 1, y - 1] != null)
					{
						Console.Write($"|{"Ház ",10}|");
					}
					else
					{
						Console.Write($"{"  ",10}");
					}
				}
				Console.WriteLine();
				for (int x = 1; x <= maxX + 1; x++)
				{
					Console.Write($"{"--------",10}");
				}
			}
			Console.WriteLine();
		}

		public static void Kiiratas()
		{
			for (int i = 0; i < buildings.Count; i++)
			{
				Console.WriteLine(buildings[i].name);
			}
		}*/
	}
}
