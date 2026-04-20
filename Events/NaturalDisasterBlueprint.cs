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
        protected int chance;
        protected int duration;

        public NaturalDisasterBlueprint(string name, int chance, int duration)
        {
            this.name = name;
            this.chance = chance;
            this.duration = duration;
        }

        public abstract void StartEffect();
        public abstract void EndEffect();
    }

}