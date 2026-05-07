using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Buildings;


namespace CitySimproj
{
    class Earthquake : NaturalDisasterBlueprint
    {
        public Earthquake() : base("Earthquake", 20, 50,"The city was shaken by a massive earthquake.") { }
    }
    class Tsunami : NaturalDisasterBlueprint
    {
        public Tsunami() : base("Tsunami", 30, 60,"A devastating tsunami has struck the city.") { }
    }
}