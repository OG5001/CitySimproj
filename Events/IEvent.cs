using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
    public interface IEvent
    {
        string Name { get; }
        string Description { get; }
        void StartEffect();
    }
}
