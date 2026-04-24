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
    // --- NATURAL DISASTERS ---

    class Earthquake : NaturalDisasterBlueprint
    {
        public Earthquake() : base("Earthquake", 20, 50) { } // Earthquake constructor, calling the base, setting the name, min and max damage.
    }

}