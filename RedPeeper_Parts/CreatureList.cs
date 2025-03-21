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
            {"bf9ccd04-60af-4144-aaa1-4ac184c686c2", TechType.PrecursorIonBattery},
            {"8d3d3c8b-9290-444a-9fea-8e5493ecd6fe", TechType.PrecursorIonBattery},
            {"5fc7744b-5a2c-4572-8e53-eebf990de434", TechType.Copper},
            {"RP_ReefbackEgg", TechType.Battery}
        };
    };
}
