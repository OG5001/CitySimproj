namespace Buildings
{
	public class Building
	{
		//Private adattagok
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

		//Public property-k

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

        // Konstruktor
        protected Building(string name, int x, int y)
		{
			this.Name = name;
			this.X = x;
			this.Y = y;
			this.CurrentHealth = MaxHealth;
		}

        //public static readonly Building CityHall= new("City Hall", 1, 1);
        //public static readonly Building Court= new("Court", 1, 1);
        //public static readonly Building FireStation = new("Fire Station", 1, 1);
        //public static readonly Building Hospital = new("Hospital", 1, 1);
        //public static readonly Building Library = new("Library", 1, 1);
        //public static readonly Building PoliceStation = new("Police Station", 1, 1);
        //public static readonly Building PostOffice= new("PostOffice", 1, 1);
        //public static readonly Building School = new("School", 1, 1);
        //public static readonly Building University = new("University", 1, 1);
        //public static readonly Building Uszoda = new("Uszoda", 1, 1);

        //így kéne példányosítani egy konkrét épületet, de mivel a még van x, y érték, ezért ezt nem használhatjuk, így a konkrét épületeket a származtatott osztályokban hozzuk létre


        //akár úgy is megoldahtó lenne ez hogy ez egy template és itt sincs benne a x,y értek, és csinálunk egy PlacedBuilding osztályt, ami tartalmazza a x,y értékeket, és azt használjuk a konkrét épületek létrehozásához, de ez egy kicsit bonyolultabb lenne, és nem látom értelmét, mivel így is megoldható a probléma



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
                    Console.WriteLine("There is already a building at this location.");
					return false;
				}
			}

			buildings.Add(building);
			return true;
		}

		// Remove metódus
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
	}
}
