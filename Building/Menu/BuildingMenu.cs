using CitySimproj.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Building
{
    internal class BuildingMenu : Menu
    {
        private static string[] mainTitle =
        {
            @" ____        _ _     _ _             ",
            @"|  _ \      (_) |   | (_)            ",
            @"| |_) |_   _ _| | __| |_ _ __   __ _ ",
            @"|  _ <| | | | | |/ _` | | '_ \ / _` |",
            @"| |_) | |_| | | | (_| | | | | | (_| |",
            @"|____/ \__,_|_|_|\__,_|_|_| |_|\__, |",
            @"                                __/ |",
            @"                               |___/ "
        };

        private static string[] options =
        {
            "Residential Building",
            "Commercial Building",
            "Industrial Building",
            "Service Building",
            "Utility Building",
            "Return to main menu"
        };

        public BuildingMenu() : base(mainTitle)
        {

        }

        public int DrawBuildingMenu()
        {
            return DrawMenu(options);
        }
    }
}
