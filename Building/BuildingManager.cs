

using CitySimproj;
using System.Net.NetworkInformation;

namespace Buildings
{
	internal class BuildingManager
	{

		static Dictionary<string, Building> buildingsBuilt = new Dictionary<string, Building>();
	
        public void Menu()
		{
			int x;
			do
			{
				Console.WriteLine("\nChoose building type\n\t1. Residential Building\n\t2. Commercial Building\n\t3. Industrial Building\n\t4. Service\n\t5. Utility\n\t6. Exit");
				x = int.Parse(Console.ReadLine());
				Console.WriteLine("-------------------------------------------");

				switch (x)
				{
					case 1:
						WriteSubtypes(typeof(Residential));
                        zetenyMiatt(typeof(Residential));
						break;
					case 2:
						WriteSubtypes(typeof(Commercial));
                        zetenyMiatt(typeof(Commercial));
						break;
					case 3:
						WriteSubtypes(typeof(Industrial));
                        zetenyMiatt(typeof(Industrial));
						break;
					case 4:
						WriteSubtypes(typeof(Service));
                        zetenyMiatt(typeof(Service));
						break;
					case 5:
						WriteSubtypes(typeof(Utility));
                        zetenyMiatt(typeof(Utility));
						break;
					case 6:
						break;
				}
			} while (x != 6);
		}

        private void WriteSubtypes(Type type)
		{
            for (int i = 0; i < Enum.GetValues(type).Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Enum.GetName(type, i)}");
            }
        }
        
        public void zetenyMiatt(Type type)

		{
            Building b;
			Console.WriteLine("-------------------------------------------");
			int XPosition = 0;
			int YPosition = 0;
            int input = int.Parse(Console.ReadLine());
			Console.WriteLine($"\nYou chose the {Enum.GetName(type, input - 1)} building.");
			do
			{
				Console.WriteLine("X coordinate (1-10):");
				XPosition = int.Parse(Console.ReadLine());
				Console.WriteLine("Y coordinate (1-10):");
				YPosition = int.Parse(Console.ReadLine());
				if (XPosition <= 0 || XPosition > 10 || YPosition <= 0 || YPosition > 10)
				{
					Console.WriteLine("It has to be between 1-10. Try again.");
				}
				else if (buildingsBuilt.Values.Any(b => b.X == XPosition && b.Y == YPosition))
				{
					Console.WriteLine("There is already a building in that spot. Choose another one.");
				}
            }
			while (XPosition <= 0 || XPosition > 10 || YPosition <= 0 || YPosition > 10 || buildingsBuilt.Values.Any(b => b.X == XPosition && b.Y == YPosition));
			if (type == typeof(Residential))
			{
				buildingsBuilt.Add($"Residential_{buildingsBuilt.Count + 1}", new ResidentialBuilding(Enum.GetName(type, input - 1), (Residential)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition));
			}
			else if (type == typeof(Commercial))
			{
				buildingsBuilt.Add($"Commercial_{buildingsBuilt.Count + 1}", new CommercialBuilding(Enum.GetName(type, input - 1), (Commercial)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition));
			}
			else if (type == typeof(Industrial))
			{
				buildingsBuilt.Add($"Industrial_{buildingsBuilt.Count + 1}", new IndustrialBuilding(Enum.GetName(type, input - 1), (Industrial)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition));
			}
			else if (type == typeof(Service))
			{
				buildingsBuilt.Add($"Service_{buildingsBuilt.Count + 1}", new ServiceBuilding(Enum.GetName(type, input - 1), (Service)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition));
            }

			else if (type == typeof(Utility))
			{
				buildingsBuilt.Add($"Utility_{buildingsBuilt.Count + 1}", new UtilityBuilding(Enum.GetName(type, input - 1), (Utility)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition));
			}
			Console.WriteLine("Sikerült :D");
		}

		

		public static void Draw()
		{
			List<Building> buildings = new List<Building>();
            foreach (KeyValuePair<string, Building> kvp in buildingsBuilt)
			{
				buildings.Add(kvp.Value);
			}

			// Meghatározzuk a pálya méretét
			int maxX = 0;
			int maxY = 0;

			for (int i = 0; i < buildings.Count; i++)
			{
				if (buildings[i].X > maxX)
				{

					maxX = buildings[i].X;
				}

				if (buildings[i].Y > maxY)
				{

					maxY = buildings[i].Y;
				}
			}

			// Mátrix létrehozása
			Building[,] matrix = new Building[maxX + 1, maxY + 1];

			// Feltöltés
			for (int i = 0; i < buildings.Count; i++)
			{
				Building b = buildings[i];
				matrix[b.X, b.Y] = b;
			}

			// Kirajzolás - 1-től kezd
			for (int y = 1; y <= maxY; y++)
			{
				for (int x = 1; x <= maxX; x++)
				{
					Console.Write($" |{"----------",10}| ");
				}
				Console.WriteLine();
				for (int x = 1; x <= maxX; x++)
				{
					if (matrix[x, y] != null)
					{
                        string elsoHat = matrix[x, y].Name.Length >= 6 ? matrix[x, y].Name.Substring(0, 6): matrix[x, y].Name;
                        Console.Write($" |{elsoHat,10}| ");
					}
					else
					{
						Console.Write($" |{" ",10}| ");
					}
				}
				Console.WriteLine();
				for (int x = 1; x <= maxX; x++)
				{
					Console.Write($" |{"----------",10}| ");
				}
				Console.WriteLine();
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		public static void Kiiratas()
		{
			foreach (KeyValuePair<string, Building> kvp in buildingsBuilt)
			{
				Console.Write($"{kvp.Key}: ");
				Console.WriteLine(kvp.Value);
			}
		}
		public static void RemoveBuilding(Building building)
		{
			string keyToRemove = null;
			foreach (KeyValuePair<string, Building> kvp in buildingsBuilt)
			{
				if (kvp.Value == building)
				{
					keyToRemove = kvp.Key;
					break;
				}
			}
			if (keyToRemove != null)
			{
				buildingsBuilt.Remove(keyToRemove);
			}
		}

		public void DefaultSetUp()
		{
			buildingsBuilt.Add("CityHall", new ServiceBuilding("City Hall", Service.CityHall, 1, 1));
			buildingsBuilt.Add("Court", new ServiceBuilding("Court", Service.Court, 1, 2));
			buildingsBuilt.Add("FireStation", new ServiceBuilding("Fire Station", Service.FireStation, 1, 3));
			buildingsBuilt.Add("Hospital", new ServiceBuilding("Hospital", Service.Hospital, 1, 4));
			buildingsBuilt.Add("PoliceStation", new ServiceBuilding("Police Station", Service.PoliceStation, 1, 5));
			buildingsBuilt.Add("School", new ServiceBuilding("School", Service.School, 1, 6));
			buildingsBuilt.Add("Apartment 1", new ResidentialBuilding("Apartment 1", Residential.ApartmentBlock, 2, 1));
            buildingsBuilt.Add("Apartment 2", new ResidentialBuilding("Apartment 2", Residential.ApartmentBlock, 2, 2));
			buildingsBuilt.Add("Supermarket", new CommercialBuilding("Supermarket", Commercial.Supermarket, 2, 3));
        }


        public static List<Building> GetAllBuildings()
        {
            return new List<Building>(buildingsBuilt.Values);
        }
    }
}