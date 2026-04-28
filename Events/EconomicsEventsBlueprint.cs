using Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{

    // The Blueprint class for Natural Disasters.
    abstract class EconomicsEventsBlueprint
    {
        private string name;

        public EconomicsEventsBlueprint(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }

        public virtual void StartEffect()
        {   
        }

        // --- Explanation ---
      
    }

}