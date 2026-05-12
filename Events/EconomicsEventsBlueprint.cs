using Buildings;
using CitySimproj.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
    // The Blueprint class for Natural Disasters.
    abstract class EconomicsEventsBlueprint : EventBlueprint
    {
        public EconomicsEventsBlueprint(string name, string description) : base(name, description)
        {
        
        }
          public override void StartEffect()
        {   
        }
    }
}