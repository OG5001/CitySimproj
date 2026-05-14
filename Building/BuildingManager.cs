using CitySimproj.Building;
using System.Security.Cryptography.X509Certificates;
using CitySimproj.Economy;

namespace Buildings
{
    internal class BuildingManager(Treasury t)
    {

        static List<BuildingLocation> buildingsBuilt = new List<BuildingLocation>();
        static List<BuildingLocation> isDamaged = new List<BuildingLocation>();
        BuildingMenu buildingMenu = new BuildingMenu();
        SubBuildingMenu subMenu = new SubBuildingMenu();

        public void Menu()
        {
            int x;
            do
            {
                x = buildingMenu.DrawBuildingMenu();

                switch (x)
                {
                    case 0:
                        zetenyMiatt(typeof(Residential));
                        break;
                    case 1:
                        zetenyMiatt(typeof(Commercial));
                        break;
                    case 2:
                        zetenyMiatt(typeof(Industrial));
                        break;
                    case 3:
                        zetenyMiatt(typeof(Service));
                        break;
                    case 4:
                        zetenyMiatt(typeof(Utility));
                        break;
                    case 5:
                        Fix ();
                        break;
                    case 6:
                        break;
                }
            } while (x != 6);
        }
        //épulet választó menü, ami a típus alapján generálja a submenu itemeket, amikben benne van az ár is

        private string[] GenerateSubMenuItems(Type type)
        {
            var values = Enum.GetValues(type);
            string[] items = new string[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                string name = Enum.GetName(type, i);
                object enumValue = Enum.Parse(type, name);

                Building prototype = null;
                if (type == typeof(Residential))
                {
                    prototype = new ResidentialBuilding(name, (Residential)enumValue, 0, 0);
                }
                else if (type == typeof(Commercial))
                {
                    prototype = new CommercialBuilding(name, (Commercial)enumValue, 0, 0);
                }
                else if (type == typeof(Industrial))
                {
                    prototype = new IndustrialBuilding(name, (Industrial)enumValue, 0, 0);
                }
                else if (type == typeof(Service))
                {
                    prototype = new ServiceBuilding(name, (Service)enumValue, 0, 0);
                }
                else if (type == typeof(Utility))
                {
                    prototype = new UtilityBuilding(name, (Utility)enumValue, 0, 0);
                }

                if (prototype != null)
                {
                    items[i] = $"{name} - Cost: {prototype.BuildingCost:0} Ft";
                }
                else
                {
                    items[i] = name;
                }
            }

            return items;
        }
        // Ez a metódus kezeli az épület elhelyezését a pályán, ellenőrzi a koordinátákat és hogy van-e már épület a helyen, majd hozzáadja az új épületet a listához
        public void zetenyMiatt(Type type)

        {
            Console.Clear();
            int XPosition = 0;
            int YPosition = 0;
            int input = subMenu.DrawMenu(GenerateSubMenuItems(type));
            Console.Clear();

            string selectedName = Enum.GetName(type, input);
            object enumValue = Enum.Parse(type, selectedName);
            Building prototype = null;
            if (type == typeof(Residential)) prototype = new ResidentialBuilding(selectedName, (Residential)enumValue, 0, 0);
            else if (type == typeof(Commercial)) prototype = new CommercialBuilding(selectedName, (Commercial)enumValue, 0, 0);
            else if (type == typeof(Industrial)) prototype = new IndustrialBuilding(selectedName, (Industrial)enumValue, 0, 0);
            else if (type == typeof(Service)) prototype = new ServiceBuilding(selectedName, (Service)enumValue, 0, 0);
            else if (type == typeof(Utility)) prototype = new UtilityBuilding(selectedName, (Utility)enumValue, 0, 0);

            decimal cost = prototype?.BuildingCost ?? 0m;
            Console.WriteLine($"\nYou chose the {selectedName} building. Cost: {cost:C0} Ft");
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
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new ResidentialBuilding(Enum.GetName(type, input), (Residential)Enum.Parse(type, Enum.GetName(type, input)), XPosition, YPosition)));
            }
            else if (type == typeof(Commercial))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new CommercialBuilding(Enum.GetName(type, input), (Commercial)Enum.Parse(type, Enum.GetName(type, input)), XPosition, YPosition)));
            }
            else if (type == typeof(Industrial))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new IndustrialBuilding(Enum.GetName(type, input), (Industrial)Enum.Parse(type, Enum.GetName(type, input)), XPosition, YPosition)));
            }
            else if (type == typeof(Service))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new ServiceBuilding(Enum.GetName(type, input), (Service)Enum.Parse(type, Enum.GetName(type, input)), XPosition, YPosition)));
            }

            else if (type == typeof(Utility))
            {
                buildingsBuilt.Add(new BuildingLocation($"{Enum.GetName(type, input)}_{buildingsBuilt.Count + 1}", XPosition, YPosition, new UtilityBuilding(Enum.GetName(type, input), (Utility)Enum.Parse(type, Enum.GetName(type, input)), XPosition, YPosition)));
            }
            Console.WriteLine("Sikerült :D");
            t.RemoveFunds((int)cost);
        }


        public static void Draw()
        {
            Console.Clear();
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
                for (int x = 1; x <= maxX; x++)
                {
                    ColorBuildings(matrix[x, y]);
                    Console.Write($" |{"----------",10}| ");
                }
                Console.WriteLine();
                for (int x = 1; x <= maxX; x++)
                {
                    if (matrix[x, y] != null)
                    {
                        ColorBuildings(matrix[x, y]);
                        
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
                    ColorBuildings(matrix[x, y]);
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
            Console.Clear();
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

        private static void ColorBuildings(BuildingLocation location)
        {
            if (location == null || location.Building == null)
            {
                Console.ResetColor();
                return;
            }

            double health = location.Building.CurrentHealth;

            if (health <= 0)
            {
                buildingsBuilt.Remove(location);
            }
            else if (health <= 20)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }

            else if (health <= 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (health <= 75)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ResetColor();
            }

        }
        public static void UpdateDamagedList()
        {
            // Check all built buildings
            foreach (var loc in buildingsBuilt)
            {
                var b = loc.Building;

                
                if (b.CurrentHealth < b.MaxHealth && b.CurrentHealth > 0)
                {
                    if (!isDamaged.Contains(loc))
                    {
                        isDamaged.Add(loc);
                    }
                }
                else
                {
                    isDamaged.Remove(loc);
                }
            }
            buildingsBuilt.RemoveAll(loc => loc.Building.CurrentHealth <= 0);
        }
        public void Fix()
        {
            UpdateDamagedList();
            Console.Clear();
            int fixCost = 0;
            int allCost = 0;
            if (isDamaged == null || isDamaged.Count == 0)
            {
                Console.WriteLine("No damaged buildings.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
                return;
            }

            while (isDamaged != null && isDamaged.Count > 0)
            {
                // Build menu: each damaged building + repair all + return
                string[] items = new string[isDamaged.Count + 2];
                for (int i = 0; i < isDamaged.Count; i++)
                {
                    var loc = isDamaged[i];
                    var b = loc.Building;
                    fixCost = (int)((b.BuildingCost * (b.MaxHealth - b.CurrentHealth)) / 100);
                    items[i] = $"{loc.Name} - X:{loc.X} Y:{loc.Y} - HP: {b.CurrentHealth}/{b.MaxHealth} - Cost: {fixCost}";
                }

                items[isDamaged.Count] = "Repair all damaged buildings";
                items[isDamaged.Count + 1] = "Back";

                int choice = subMenu.DrawMenu(items);
                Console.Clear();

                if (choice < 0 || choice > isDamaged.Count + 1)
                {
                    // defensive: return to main menu on unexpected value
                    return;
                }

                if (choice < isDamaged.Count)
                {
                    // Repair selected building
                    var loc = isDamaged[choice];
                    loc.Building.CurrentHealth = loc.Building.MaxHealth;
                    Console.WriteLine($"Repaired: {loc.Name} (X:{loc.X} Y:{loc.Y}).");
                    isDamaged.RemoveAt(choice);
                    t.RemoveFunds(fixCost);

                    if (isDamaged.Count == 0)
                    {
                        Console.WriteLine("All damaged buildings repaired.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        return;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }

                if (choice == isDamaged.Count)
                {
                    // Repair all
                    foreach (var loc in isDamaged.ToList())
                    {
                        allCost += (int)((loc.Building.BuildingCost * (loc.Building.MaxHealth - loc.Building.CurrentHealth)) / 100);
                        loc.Building.CurrentHealth = loc.Building.MaxHealth;
                    }
                    isDamaged.Clear();
                    t.RemoveFunds(allCost);
                    Console.WriteLine("All damaged buildings repaired.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    return;
                }

                // Return to main menu
                return;
            }
        }
    }
}