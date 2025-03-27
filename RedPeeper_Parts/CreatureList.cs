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
            {"RP_ReefbackEgg", СывороткаПлоти.Info.TechType}, // ЯйцоРифоспина +
            {"f78942c3-87e7-4015-865a-5ae4d8bd9dcb", ЭхоГен.Info.TechType}, //Жнец +
            {"ff43eacd-1a9e-4182-ab7b-aa43c16d1e53", БиоТерм.Info.TechType}, //Дракон +

            {"35ee775a-d54c-4e63-a058-95306346d582", ПищФер.Info.TechType}, //Топтун +
            {"54701bfc-bb1a-4a84-8f79-ba4f76691bef", АмоГель.Info.TechType}, //Призрак +

            {"4c2808fe-e051-44d2-8e64-120ddcdc8abb", КомпДавл.Info.TechType}, //Кальмарокраб +
            {"e69be2e8-a2e3-4c4c-a979-281fbf221729", ЭлТкань.Info.TechType} //Угорь +
        };
    };
}
