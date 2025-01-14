using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedPeeper_Parts
{
    public static class CreatureList
    {
        public static Dictionary<TechType, TechType> Creatures = new Dictionary<TechType, TechType>()
        {
            {TechType.Peeper, TechType.Titanium}
        };
    };
}
