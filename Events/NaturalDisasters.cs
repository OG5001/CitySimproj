using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{

    class NaturalDisasters : NaturalDisasterBlueprint
    {
        public NaturalDisasters(string name, int chance, int duration) : base(name, chance, duration)
        {
        }

        public override void StartEffect()
        {
            // Implementation for starting the natural disaster effect
        }

        public override void EndEffect()
        {
            // Implementation for ending the natural disaster effect
        }
    }

}