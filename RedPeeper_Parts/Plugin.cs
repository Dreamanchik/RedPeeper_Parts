using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
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
            //  ITEMS
            //    ADVANCED MATERIALS
            RedPeeper_StorageConcentrate.Register();
            RedPeeper_PlasmaLens.Register();
            RedPeeper_SolarCell.Register();
            RedPeeper_Spatial_Processor.Register();
            //    BATTERIES

            //    CYCLOPS
            RedPeeper_CyclopsEngine.Register();
            RedPeeper_CyclopsHull.Register();
            RedPeeper_CyclopsBridge.Register();
            //    ELECTRONICS

            //    MATERIALS

            //    EXOSUIT
            HolyOasis_PrawnArm.Register();
            HolyOasis_PrawnLeg.Register();

        }
    }
}