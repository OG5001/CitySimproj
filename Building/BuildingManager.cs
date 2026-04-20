

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
				Console.WriteLine("Válassz az alábbiak közül\n\t1. Residential Building\n\t2. Commercial Building\n\t3. Industrial Building\n\t4. Service\n\t5. Utility\n\t6. Kilépés");
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
						Console.WriteLine("Vissza a főmenüre");
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
			Console.WriteLine($"Kiválasztottad a {Enum.GetName(type, input - 1)} épületet.");
			do
			{
				Console.WriteLine("Add meg az X koordinátát:");
				XPosition = int.Parse(Console.ReadLine());
				Console.WriteLine("Add meg az Y koordinátát:");
				YPosition = int.Parse(Console.ReadLine());
			}
			while (XPosition <= 0 || XPosition >= 10 || YPosition <= 0 || YPosition >= 10); 
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
						Console.Write($" |{matrix[x, y].Name,10}| ");
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
        }


        public static List<Building> GetAllBuildings()
        {
            return new List<Building>(buildingsBuilt.Values);
        }
    }
}