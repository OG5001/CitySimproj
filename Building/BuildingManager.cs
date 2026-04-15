

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
			int input = int.Parse(Console.ReadLine());
			Console.WriteLine($"Kiválasztottad a {Enum.GetName(type, input - 1)} épületet.");
			Console.WriteLine("Melyik X és Y értékre szeretnéd ülteti: ");
			int XPosition = int.Parse(Console.ReadLine());
			int YPosition = int.Parse(Console.ReadLine());
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
				switch ((Service)(input - 1))
				{
					case Service.School: b = new SchoolBuilding(XPosition, YPosition); break;
					case Service.University: b = new UniversityBuilding(XPosition, YPosition); break;
					case Service.Hospital: b = new Hospital(XPosition, YPosition); break;
					case Service.PoliceStation: b = new PoliceStationBuilding(XPosition, YPosition); break;
					case Service.FireStation: b = new FireStationBuilding(XPosition, YPosition); break;
					case Service.PostOffice: b = new PostOfficeBuilding(XPosition, YPosition); break;
					case Service.Library: b = new LibraryBuilding(XPosition, YPosition); break;
					case Service.CityHall: b = new CityHallBuilding(XPosition, YPosition); break;
					case Service.Court: b = new CourtBuilding(XPosition, YPosition); break;
					case Service.Uszoda: b = new UszodaBuilding(XPosition, YPosition); break;
					default: b = new ServiceBuilding(Enum.GetName(type, input - 1), (Service)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition); break;
				}
				buildingsBuilt.Add(type.Name, b);
			}

			else if (type == typeof(Utility))
			{
				buildingsBuilt.Add($"Utility_{buildingsBuilt.Count + 1}", new UtilityBuilding(Enum.GetName(type, input - 1), (Utility)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition));
			}
			Console.WriteLine("Sikerült :D");
		}/*
	public void zetenyMiatt(Type type)
		{
			Console.WriteLine("-------------------------------------------");
			int input = int.Parse(Console.ReadLine());

			string name = Enum.GetName(type, input - 1); //Program

			Console.WriteLine($"Kiválasztottad a {name} épületet.");
			Console.WriteLine("Melyik X és Y értékre szeretnéd ülteti: ");

			int x = int.Parse(Console.ReadLine());
			int y = int.Parse(Console.ReadLine());

			Building b;

			if (type == typeof(Residential))
				b = new ResidentialBuilding(name, x, y);

			else if (type == typeof(Commercial))
				b = new CommercialBuilding(name, x, y);

			else if (type == typeof(Industrial))
				b = new IndustrialBuilding(name, x, y);

			else if (type == typeof(Utility))
				b = new UtilityBuilding(name, x, y);

			else if (type == typeof(Service))
			{
				switch ((Service)(input - 1))
				{
					case Service.School: b = new SchoolBuilding(x, y); break;
					case Service.University: b = new UniversityBuilding(x, y); break;
					case Service.Hospital: b = new Hospital(x, y); break;
					case Service.PoliceStation: b = new PoliceStationBuilding(x, y); break;
					case Service.FireStation: b = new FireStationBuilding(x, y); break;
					case Service.PostOffice: b = new PostOfficeBuilding(x, y); break;
					case Service.Library: b = new LibraryBuilding(x, y); break;
					case Service.CityHall: b = new CityHallBuilding(x, y); break;
					case Service.Court: b = new CourtBuilding(x, y); break;
					case Service.Uszoda: b = new UszodaBuilding(x, y); break;

					default: b = new ServiceBuilding(name, x, y); break;
				}
			}
			else
			{
				throw new Exception("Ismeretlen típus");
			}

			// after successfully adding a building
			if (Building.Add(b))
			{
				Console.WriteLine("Sikerült :D");
				Building.Draw(); // <-- call Draw here to see the updated grid immediately
			}
			else
			{
				Console.WriteLine("Nem sikerült (foglalt hely)");
			}
		}
		*/
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

			// Kirajzolás
			for (int y = 1; y <= maxY + 1; y++)
			{
				for (int x = 1; x <= maxX + 1; x++)
				{
					Console.Write($" |{"----------",10}| ");
				}
				Console.WriteLine();
				for (int x = 1; x <= maxX + 1; x++)
				{
					if (matrix[x - 1, y - 1] != null)
					{
						Console.Write($" |{matrix[x - 1, y - 1].Name,10}| ");

					}
					else
					{
						Console.Write($" |{" ",10}| ");
					}
				}
				Console.WriteLine();
				for (int x = 1; x <= maxX + 1; x++)
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
	}
}
