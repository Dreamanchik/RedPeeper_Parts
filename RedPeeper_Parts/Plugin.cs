using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
using System.Reflection;

namespace RedPeeper_Parts
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // Initialize custom prefabs
            InitializePrefabs();

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void InitializePrefabs()
        {
            //    РЕГИСТРАЦИЯ ВСЕХ ПРЕФАБОВ
            //  (Название файла).Register();
            //  ITEMS
            //    ADVANCED MATERIALS
            RedPeeper_StorageConcentrate.Register();
            RedPeeper_PlasmaLens.Register();
            RedPeeper_SolarCell.Register();
            RedPeeper_Spatial_Processor.Register();
            Logger.LogInfo("ITEMS/ADVANCED MATERIALS LOADED");
            //    BATTERIES

            //    CYCLOPS
            RedPeeper_CyclopsEngine.Register();
            RedPeeper_CyclopsHull.Register();
            RedPeeper_CyclopsBridge.Register();
            Logger.LogInfo("ITEMS/CYCLOPS LOADED");
            //    ELECTRONICS

            //    MATERIALS

            //    EXOSUIT
            HolyOasis_PrawnArm.Register();
            HolyOasis_PrawnLeg.Register();
            Logger.LogInfo("ITEMS/EXOSUIT LOADED");
            //    EQUIPMENT
            //      QUICKSLOTS
            //ScannerTest.Register();

            //  RECIPES
            //  CraftDataHandler.SetRecipeData(Techtype.(Айди предмета рецепт которого меняем), (Название файла с рецептом).GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.Cyclops, CyclopsRecipe.GetRecipeData());

            //Доп. Материалы
            CraftDataHandler.SetItemSize(TechType.Aerogel, new Vector2int(2, 2));
            CraftDataHandler.SetRecipeData(TechType.Aerogel, AerogelRecipe.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.Benzene, new Vector2int(1, 2));
            CraftDataHandler.SetRecipeData(TechType.Benzene, BenzeneRecipe.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.HydrochloricAcid, new Vector2int(1, 2));
            CraftDataHandler.SetRecipeData(TechType.HydrochloricAcid, HydrochloricAcidRecipe.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.AramidFibers, new Vector2int(2, 1));
            CraftDataHandler.SetRecipeData(TechType.AramidFibers, AramidFibersRecipe.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.Polyaniline, new Vector2int(1, 2));
            CraftDataHandler.SetRecipeData(TechType.Polyaniline, PolyanilineRecipe.GetRecipeData());




            //Электроника
            CraftDataHandler.SetRecipeData(TechType.AdvancedWiringKit, AdvancedKitlRecipe.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.CopperWire, CopperWireRecipe.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.ComputerChip, ComputerChipRecipe.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.ReactorRod, ReactorRodRecipe.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.WiringKit, WiringKitRecipe.GetRecipeData());
            Logger.LogInfo("RECIPES LOADED");

        }
    }
}