using CitySimproj.Shared;

namespace CitySimproj.Building
{
    internal class SubBuildingMenu : Menu
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

        public SubBuildingMenu() : base(mainTitle)
        {

        }
    }
}
