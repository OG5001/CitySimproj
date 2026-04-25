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
        public Earthquake() : base("Earthquake", 20, 50) { }
    }
    class Tsunami : NaturalDisasterBlueprint
    {
        public Tsunami() : base("Tsunami", 30, 60) { }
    }

    // Explanation
    // Constructor of the Disaster class, which inherits from the NaturalDisasterBlueprint class. 
    // The effect is not called, but with the parameters given here, the Effects will use different parameters.

}