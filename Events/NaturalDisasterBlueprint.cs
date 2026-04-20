using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{

    // The Blueprint class for Natural Disasters.
    abstract class NaturalDisasterBlueprint
    {
        protected string name;

        public NaturalDisasterBlueprint(string name)
        {
            this.name = name;
        }

        public abstract void StartEffect();
    }

}