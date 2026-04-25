using Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Building
{
    public class BuildingLocation(string name, int x, int y, Buildings.Building building) : ILocation
    {
        public string Name { get; private set; } = name;
        public int X { get; private set; } = x;
        public int Y { get; private set; } = y;
        public Buildings.Building Building { get; private set; } = building;

        public override string ToString()
        {
            return $"{Name}, X: {X}, Y: {Y}, Building: {Building.ToString()}";
        }
    }
}