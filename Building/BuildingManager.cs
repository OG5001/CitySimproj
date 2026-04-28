using CitySimproj.Building;
using System.Security.Cryptography.X509Certificates;

namespace Buildings
{
    internal class BuildingManager
    {

        static List<BuildingLocation> buildingsBuilt = new List<BuildingLocation>();

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
                else if (buildingsBuilt.Find(b => b.X == XPosition && b.Y == YPosition) != null)
                {
                    Console.WriteLine("There is already a building in that spot. Choose another one.");
                }
            }
            while (XPosition <= 0 || XPosition > 10 || YPosition <= 0 || YPosition > 10 || buildingsBuilt.Find(b => b.X == XPosition && b.Y == YPosition) != null);
            if (type == typeof(Residential))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input - 1)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new ResidentialBuilding(Enum.GetName(type, input - 1), (Residential)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition)));
            }
            else if (type == typeof(Commercial))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input - 1)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new CommercialBuilding(Enum.GetName(type, input - 1), (Commercial)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition)));
            }
            else if (type == typeof(Industrial))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input - 1)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new IndustrialBuilding(Enum.GetName(type, input - 1), (Industrial)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition)));
            }
            else if (type == typeof(Service))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input - 1)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new ServiceBuilding(Enum.GetName(type, input - 1), (Service)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition)));
            }

            else if (type == typeof(Utility))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input - 1)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new UtilityBuilding(Enum.GetName(type, input - 1), (Utility)Enum.Parse(type, Enum.GetName(type, input - 1)), XPosition, YPosition)));
            }
            Console.WriteLine("Sikerült :D");
        }



        public static void Draw()
        {
            List<BuildingLocation> buildings = new List<BuildingLocation>();
            foreach (BuildingLocation b in buildingsBuilt)
            {
                buildings.Add(b);
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
            BuildingLocation[,] matrix = new BuildingLocation[maxX + 1, maxY + 1];

            // Feltöltés
            for (int i = 0; i < buildings.Count; i++)
            {
                BuildingLocation b = buildings[i];
                matrix[b.X, b.Y] = b;


            }
            // Kirajzolás - 1-től kezd
            for (int y = 1; y <= maxY; y++)
            {
                
                ColorBuildings();
                for (int x = 1; x <= maxX; x++)
                {
                    Console.Write($" |{"----------",10}| ");
                }
                Console.WriteLine();
                for (int x = 1; x <= maxX; x++)
                {
                    if (matrix[x, y] != null)
                    {
                        
                        string elsoHat = matrix[x, y].Name.Length >= 6 ? matrix[x, y].Name.Substring(0, 6) : matrix[x, y].Name;
                        Console.Write($" |{elsoHat,10}| ");
                    }
                    else
                    {
                        Console.ResetColor();
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
            Console.ResetColor();
        }
        public static void Kiiratas()
        {
            foreach (BuildingLocation b in buildingsBuilt)
            {
                Console.WriteLine(b.ToString());
            }
        }
        public static void RemoveBuildingByName(string name)
        {
            buildingsBuilt.RemoveAll(b => b.Name == name);
        }

        public static void RemoveBuildingByLocation(int x, int y)
        {
            buildingsBuilt.RemoveAll(b => b.X == x - 1 && b.Y == y - 1);
        }

        public void DefaultSetUp()
        {
            buildingsBuilt.Add(new BuildingLocation("City Hall", 1, 1, new ServiceBuilding("City Hall", Service.CityHall, 1, 1)));
            buildingsBuilt.Add(new BuildingLocation("Court", 1, 2, new ServiceBuilding("Court", Service.Court, 1, 2)));
            buildingsBuilt.Add(new BuildingLocation("Fire Station", 1, 3, new ServiceBuilding("Fire Station", Service.FireStation, 1, 3)));
            buildingsBuilt.Add(new BuildingLocation("Hospital", 1, 4, new ServiceBuilding("Hospital", Service.Hospital, 1, 4)));
            buildingsBuilt.Add(new BuildingLocation("Police Station", 1, 5, new ServiceBuilding("Police Station", Service.PoliceStation, 1, 5)));
            buildingsBuilt.Add(new BuildingLocation("School", 1, 6, new ServiceBuilding("School", Service.School, 1, 6)));
            buildingsBuilt.Add(new BuildingLocation("Apartment 1", 2, 1, new ResidentialBuilding("Apartment 1", Residential.ApartmentBlock, 2, 1)));
            buildingsBuilt.Add(new BuildingLocation("Apartment 2", 2, 2, new ResidentialBuilding("Apartment 2", Residential.ApartmentBlock, 2, 2)));
            buildingsBuilt.Add(new BuildingLocation("Supermarket", 2, 3, new CommercialBuilding("Supermarket", Commercial.Supermarket, 2, 3)));
            buildingsBuilt.Add(new BuildingLocation("Solarplant", 3, 1, new UtilityBuilding("Solarplant", Utility.SolarPlant, 3, 1)));
            buildingsBuilt.Add(new BuildingLocation("Watertreatmentplant", 3, 2, new UtilityBuilding("Watertreatmentplant", Utility.WaterTreatmentPlant, 3, 2)));
        }


        public static List<Building> GetAllBuildings()
        {
            return buildingsBuilt.Select(b => b.Building).ToList();
        }

        public static List<BuildingLocation> GetAllBuildingLocations()
        {
            return buildingsBuilt;
        }

        public static void ColorBuildings()
        {
            foreach (BuildingLocation b in buildingsBuilt)
            {
                if (b.Building != null && b.Building.CurrentHealth < 20)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else if (b.Building != null && b.Building.CurrentHealth < 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (b.Building != null && b.Building.CurrentHealth < 60)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
        }
    }
}