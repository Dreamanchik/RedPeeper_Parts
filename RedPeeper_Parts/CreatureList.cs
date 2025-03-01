using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPeeper_Parts
{
    public static class CreatureList
    {
        public static Dictionary<string, TechType> Creatures = new Dictionary<string, TechType>()
        {
            {"3fcd548b-781f-46ba-b076-7412608deeef", TechType.Titanium},
            {"bf9ccd04-60af-4144-aaa1-4ac184c686c2", TechType.PrecursorIonBattery}
        };
    };
}
