using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_metaprogramming.Examples.Car
{
  class Tesla : Car
  {
    public Tesla() : base()
    {
       features = new List<string> {
        "Wheels", "Windows", "AirConditioning",
        "Turbo", "MoonRoof", "TouchScreen"
      };
    }


  }
}
