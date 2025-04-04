namespace RedPeeper_Parts.Датабоксы
{
    using CustomDataboxes.API;
    using BepInEx;

    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInDependency("com.snmodding.nautilus", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.CustomDataboxes.Metious", BepInDependency.DependencyFlags.HardDependency)]
    public class ДатСолнЯч : BaseUnityPlugin
    {
        private const string
           MODNAME = "CustomDataBoxtest",
           AUTHOR = "Cookay",
           GUID = "com.CustomDataBoxtest.CKmod",
           VERSION = "1.0.0.0";

        private readonly string alreadyUnlockedTooltip = "Чертёж уже получен";
        private readonly string primaryTooltip = "Солнечная ячейка";
        private readonly string secondaryTooltip = "?";
        private readonly string ClassID = "Ящик с данными - Солнечная ячейка";
        private readonly TechType unlockTechType = СолнечнаяЯчейка.Info.TechType;


        public void Awake()
        {
            Databox myDatabox = new Databox()
            {
                DataboxID = "RP_SolarCellDatabox",
                PrimaryDescription = "Ящик с данными",
                SecondaryDescription = "Содержит чертёж солнечной ячейки.",
                TechTypeToUnlock = СолнечнаяЯчейка.Info.TechType
            };
            myDatabox.Patch(); // Once patched, you're good to go.




        }

    }
    public class ДатПроцПроц : BaseUnityPlugin
    {
        private const string
           MODNAME = "CustomDataBoxtest",
           AUTHOR = "Cookay",
           GUID = "com.CustomDataBoxtest.CKmod",
           VERSION = "1.0.0.0";

        private readonly string alreadyUnlockedTooltip = "Чертёж уже получен";
        private readonly string primaryTooltip = "Пространственный процессор";
        private readonly string secondaryTooltip = "?";
        private readonly string ClassID = "Ящик с данными - Пространственный процессор";
        private readonly TechType unlockTechType = ПространственныйПроцессор.Info.TechType;


        public void Awake()
        {
            Databox myDatabox = new Databox()
            {
                DataboxID = "RP_SpatialProcessorDatabox",
                PrimaryDescription = "Ящик с данными",
                SecondaryDescription = "Содержит чертёж пространственного процессора.",
                TechTypeToUnlock = ПространственныйПроцессор.Info.TechType
            };




        }

    }
    public class ДатПлазменнЛинза : BaseUnityPlugin
    {
        private const string
           MODNAME = "CustomDataBoxtest",
           AUTHOR = "Cookay",
           GUID = "com.CustomDataBoxtest.CKmod",
           VERSION = "1.0.0.0";

        private readonly string alreadyUnlockedTooltip = "Чертёж уже получен";
        private readonly string primaryTooltip = "Плазменная линза";
        private readonly string secondaryTooltip = "?";
        private readonly string ClassID = "Ящик с данными - Плазменная линза";
        private readonly TechType unlockTechType = ПлазменнаяЛинза.Info.TechType;


        public void Awake()
        {
            Databox myDatabox = new Databox()
            {
                DataboxID = "RP_PlasmaLensDatabox",
                PrimaryDescription = "Ящик с данными",
                SecondaryDescription = "Содержит чертёж плазменной линзы.",
                TechTypeToUnlock = ПлазменнаяЛинза.Info.TechType
            };




        }

    }
    public class ДатСтроителя : BaseUnityPlugin
    {
        private const string
           MODNAME = "CustomDataBoxtest",
           AUTHOR = "Cookay",
           GUID = "com.CustomDataBoxtest.CKmod",
           VERSION = "1.0.0.0";

        private readonly string alreadyUnlockedTooltip = "Чертёж уже получен";
        private readonly string primaryTooltip = "Строитель";
        private readonly string secondaryTooltip = "?";
        private readonly string ClassID = "Ящик с данными - Строитель";
        private readonly TechType unlockTechType = TechType.Builder;


        public void Awake()
        {
            Databox myDatabox = new Databox()
            {
                DataboxID = "RP_BuilderDatabox",
                PrimaryDescription = "Ящик с данными",
                SecondaryDescription = "Содержит чертёж строителя.",
                TechTypeToUnlock = TechType.Builder
            };
            myDatabox.Patch(); // Once patched, you're good to go.




        }

    }
}
