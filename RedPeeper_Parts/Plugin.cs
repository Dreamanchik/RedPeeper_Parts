using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
using Nautilus.Utility;
using System.Reflection;
using UnityEngine;
using RedPeeper;


namespace RedPeeper_Parts
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();
        public static AssetBundle AssetBundle { get; set; } = AssetBundleLoadingUtils.LoadFromAssetsFolder(Plugin.Assembly, "redpeeper");

        public void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // Initialize custom prefabs
            InitializePrefabs();
            StructureLoading.RegisterStructures();

            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            EnergyMixinPatch.Patch(harmony);

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void InitializePrefabs()
        {

            //Убираем предметы из изготовителя
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "Electronics", "PrecursorIonBattery");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "Electronics", "PrecursorIonPowerCell");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "Electronics", "AdvancedWiringKit");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "Electronics", "ReactorRod");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "Electronics", "Battery");

            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "BasicMaterials", "Bleach");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "BasicMaterials", "EnameledGlass");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "BasicMaterials", "PlasteelIngot");

            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "AdvancedMaterials", "Benzene");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "AdvancedMaterials", "HydrochloricAcid");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "AdvancedMaterials", "AramidFibers");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "AdvancedMaterials", "Aerogel");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "AdvancedMaterials", "Polyaniline");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Resources", "AdvancedMaterials", "HatchingEnzymes");



            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Equipment", "ReinforcedDiveSuit");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Equipment", "WaterFiltrationSuit");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Equipment", "PrecursorKey_Purple");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Equipment", "PrecursorKey_Blue");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Equipment", "PrecursorKey_Orange");

            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Tools", "Builder");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Tools", "LaserCutter");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Tools", "StasisRifle");
            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Personal", "Tools", "PropulsionCannon");



            CraftTreeHandler.RemoveNode(CraftTree.Type.Fabricator, "Machines", "CyclopsDecoy");


            // Перфабы генерации
            // Базы
            CleanFoundation.Register();
            DegasiBase.Register();
            DegasiBasePieceCorridorCap.Register();
            DegasiBasePieceCorridorTopOpen.Register();
            DegasiBasePieceCorridorTopOpenLadder.Register();
            DegasiBasePieceMultipurpose.Register();
            DegasiBasePieceMultipurposePlanters.Register();
            DegasiBasePieceTCorridorGlass.Register();
            DegasiBasePieceXCorridor.Register();

            // Обломки
            DunesWreckCopy.Register();
            GrassyWreckCopy.Register();

            // Ящики
            SealedCrateCopy.Register();
            CrateCopy.Register();

            // Ресурсы
            DrillableReefbackRock.Register();

            // Камни
            КаменьБезФизики1.Register();
            КаменьБезФизики2.Register();
            КаменьБезФизики3.Register();
            КаменьБезФизики4.Register();
            КаменьБезФизики5.Register();

            // КПК
            //PDATest.Register();
            //PDATestEntry.Register();

            // Сканируемое
            AncientSandworm.Register();
            AncientSandwormPDA.Register();
            ScannableShelvesCollider.Register();
            ReefbackNestPDA.Register();

            // Яйца
            ЯйцоРифоспина.Register();





            // ПРЕДМЕТЫ

            // Новые предметы
            НакопительныйКонцентрат.Register();
            ПлазменнаяЛинза.Register();
            СолнечнаяЯчейка.Register(); 
            ПространственныйПроцессор.Register();
            Герметик.Register();
            ОкаменелостиРифоспинов.Register();
            СолнечнаяЯчейкаДатабокс.Register();
            Мембрана2.Register();
            ДвухфакторныйИнициализатор.Register();
            Logger.LogInfo("Новые предметы загружены");





            // Новая еда
            RedPeeper_MelonMousse.Register();
            RedPeeper_AcidConcentrate.Register();
            ОбедФаберже.Register();





            // Батареи
            УпаковочнаяТкань.Register();
            МеднаяБатарейка.Register();
            АналоговаяБатарея.Register();
            Энергоячейка2.Register();
            СветоваяБатарейка.Register();




            // Части Циклопа
            ДвигательЦиклопа.Register();
            КорпусЦиклопа.Register();
            МостикЦиклопа.Register();
            Logger.LogInfo("Части Циклопа загружены");





            // Части Краба
            МанипуляторКраба.Register();
            НогаКраба.Register();
            Logger.LogInfo("Части Краба загружены");





            // Тестовые предметы
            //RedPeeper_TrainingPeeper.Register();
            //DrillablePeeper.Register();




            // Снаряжение




            // Регистрация ДНК передатчика
            DNASampler.Register();





            // Синтезируемое
            АмоГель.Register();
            БиоТерм.Register();
            КомпДавл.Register();
            ПищФер.Register();
            ПрыжБиохим.Register();
            СывороткаПлоти.Register();
            ЭлТкань.Register();
            ЭхоГен.Register();
            Logger.LogInfo("Синтезируемые материалы загружены");





            // ПОСТРОЙКИ
            // Изготовитель
            МодифицированныйИзготовитель.Register();




            // Хранилища
            ПромышленныйСтеллаж.Register();
            АварийныйКонтейнер.Register();
            НапольныйШкаф.Register();
            ИонныйНакопитель.Register();

            // Синтезируемое
            /*АмоГель.Register();
            БиоТерм.Register();
            КомпДавл.Register();
            ПищФер.Register();
            ПрыжБиохим.Register();
            СывороткаПлоти.Register();
            ЭлТкань.Register();
            ЭхоГен.Register();
            Logger.LogInfo("Синтезируемые материалы загружены");*/


            СолнечнаяЯчейкаДатабокс2.Register();
            СветоваяБатареяДатабокс.Register();

            // Патчим рецепты

            // Модули
            CraftDataHandler.SetRecipeData(TechType.ExosuitDrillArmModule, РецептБуровойРуки.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.ExosuitGrapplingArmModule, РецептКрюковойРуки.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.ExosuitThermalReactorModule, РецептТермоРеактора.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.VehicleHullModule1, РецептКорпусаЭкзокостюма1.GetRecipeData());

            CraftDataHandler.SetRecipeData(TechType.VehicleArmorPlating, РецептБрониТранспорта.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.VehiclePowerUpgradeModule, РецептУлучшенияЭнергии.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.VehicleStorageModule, РецептМодуляХранения.GetRecipeData());

            CraftDataHandler.SetRecipeData(TechType.SeamothSolarCharge, РецептСолнечнойЗарядки.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.SeamothElectricalDefense, РецептЭлектрообороны.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.SeamothSonarModule, РецептМодуляСонара.GetRecipeData());

            // МодСтанция
            CraftDataHandler.SetRecipeData(TechType.HighCapacityTank, РецептБаллонаСверхвысокойЁмкости.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.ExoHullModule2, РецептГлубиныПогруженияКостюмаКРАБ2.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.UltraGlideFins, РецептСверхскользкихЛаст.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.SwimChargeFins, РецептЛастыЗарядки.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.PlasteelTank, РецептЛёгкогоБаллонаВысокойЁмкости.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.LithiumIonBattery, РецептЛитийИоннойБатареи.GetRecipeData());

            CraftDataHandler.SetRecipeData(TechType.VehicleHullModule2, РецептМодуляГлубиныПогруженияМотылька2.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.VehicleHullModule3, РецептМодуляГлубиныПогруженияМотылька3.GetRecipeData());

            CraftDataHandler.SetRecipeData(TechType.CyclopsHullModule2, РецептМодуляГлубиныПогруженияЦиклопа2.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.CyclopsHullModule3, РецептМодуляГлубиныПогруженияЦиклопа3.GetRecipeData());

            // Инструменты
            CraftDataHandler.SetRecipeData(TechType.PropulsionCannon, РецептПропульсионнойПушки.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.StasisRifle, РецептСтазисВинтовки.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.LaserCutter, РецептЛазерногоРезака.GetRecipeData());

            // Интерактивные части базы
            CraftDataHandler.SetRecipeData(TechType.BaseLadder, РецептЛестницы.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.BaseFiltrationMachine, РецептВодоотчистнойСтанции.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.BaseBulkhead, РецептПереборки.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.BaseUpgradeConsole, РецептКонсолиУлучшения.GetRecipeData());

            // Энергия
            CraftDataHandler.SetRecipeData(TechType.SolarPanel, РецептСолнечнойПанели.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.BaseBioReactor, РецептБиоРеактора.GetRecipeData());

            // Доп. Материалы
            CraftDataHandler.SetItemSize(TechType.Aerogel, new Vector2int(3, 2));
            CraftDataHandler.SetRecipeData(TechType.Aerogel, РецептАэрогеля.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.Benzene, new Vector2int(2, 3));
            CraftDataHandler.SetRecipeData(TechType.Benzene, РецептБензола.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.HydrochloricAcid, new Vector2int(2, 2));
            CraftDataHandler.SetRecipeData(TechType.HydrochloricAcid, РецептСолянойКислоты.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.AramidFibers, new Vector2int(3, 2));
            CraftDataHandler.SetRecipeData(TechType.AramidFibers, РецептСинтетическихВолокон.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.Polyaniline, new Vector2int(2, 3));
            CraftDataHandler.SetRecipeData(TechType.Polyaniline, РецептПолианилина.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.HatchingEnzymes, new Vector2int(2, 3));

            // Конструктор
            CraftDataHandler.SetRecipeData(TechType.Exosuit, РецептКраба.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.Cyclops, РецептЦиклопа.GetRecipeData());

            // ДеталиБазы
            CraftDataHandler.SetRecipeData(TechType.BaseLargeRoom, РецептБольшойКомнаты.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.BaseObservatory, РецептОбсеватории.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.BaseMoonpool, РецептСтыковочнойШахты.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.BaseRoom, РецептМногоцелевойКомнаты.GetRecipeData());





            // Электроника

            CraftDataHandler.SetRecipeData(TechType.CopperWire, РецептМедногоПровода.GetRecipeData());
            CraftDataHandler.SetItemSize(TechType.CopperWire, new Vector2int(2, 1));


            CraftDataHandler.SetRecipeData(TechType.ComputerChip, РецептМикросхемы.GetRecipeData());
            CraftDataHandler.SetItemSize(TechType.ComputerChip, new Vector2int(2, 2));

            CraftDataHandler.SetRecipeData(TechType.WiringKit, РецептКомплектаПроводов.GetRecipeData());
            CraftDataHandler.SetItemSize(TechType.WiringKit, new Vector2int(2, 2));


            CraftDataHandler.SetRecipeData(TechType.AdvancedWiringKit, РецептРасширенногоКомплектаПроводов.GetRecipeData());
            CraftDataHandler.SetItemSize(TechType.AdvancedWiringKit, new Vector2int(3, 2));


            CraftDataHandler.SetRecipeData(TechType.ReactorRod, РецептСтержняРеактора.GetRecipeData());
            CraftDataHandler.SetItemSize(TechType.ReactorRod, new Vector2int(3, 4));

            CraftDataHandler.SetRecipeData(TechType.PowerCell, РецептЭнергоячейки.GetRecipeData());





            // Материалы
            CraftDataHandler.SetItemSize(TechType.Bleach, new Vector2int(1, 2));
            CraftDataHandler.SetRecipeData(TechType.Bleach, РецептАнтисептика.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.PlasteelIngot, new Vector2int(3, 2));
            CraftDataHandler.SetRecipeData(TechType.PlasteelIngot, РецептПласталевогоСлитка.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.Silicone, new Vector2int(2, 1));
            CraftDataHandler.SetRecipeData(TechType.Silicone, РецептСиликоновойРезины.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.FiberMesh, new Vector2int(2, 1));

            CraftDataHandler.SetRecipeData(TechType.Glass, РецептСтекла.GetRecipeData());
            CraftDataHandler.SetItemSize(TechType.Glass, new Vector2int(2, 1));

            CraftDataHandler.SetItemSize(TechType.TitaniumIngot, new Vector2int(2, 2));
            CraftDataHandler.SetRecipeData(TechType.TitaniumIngot, РецептТитановогоСлитка.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.EnameledGlass, new Vector2int(3, 2));
            CraftDataHandler.SetRecipeData(TechType.EnameledGlass, РецептЭмалевогоСтекла.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.Lubricant, new Vector2int(1, 2));





            // Оборудование
            CraftDataHandler.SetItemSize(TechType.FirstAidKit, new Vector2int(1, 2));
            CraftDataHandler.SetRecipeData(TechType.FirstAidKit, РецептАптечки.GetRecipeData());

            CraftDataHandler.SetRecipeData(TechType.Tank, РецептКислородногоБаллона.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.DoubleTank, РецептКислородногоБаллонаВысокойЁмкости.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.Compass, new Vector2int(2, 2));
            CraftDataHandler.SetRecipeData(TechType.Compass, РецептКомпаса.GetRecipeData());

            CraftDataHandler.SetRecipeData(TechType.Fins, РецептЛаст.GetRecipeData());

            CraftDataHandler.SetItemSize(TechType.FireExtinguisher, new Vector2int(1, 2));
            CraftDataHandler.SetRecipeData(TechType.FireExtinguisher, РецептОгнетушителя.GetRecipeData());

            CraftDataHandler.SetRecipeData(TechType.Rebreather, РецептРебризера.GetRecipeData());




            // Инструменты
            CraftDataHandler.SetRecipeData(TechType.Scanner, РецептСканера.GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.Flashlight, РецептФонарика.GetRecipeData());


            CraftDataHandler.SetItemSize(TechType.LEDLight, new Vector2int(1, 2));
            CraftDataHandler.SetItemSize(TechType.Flashlight, new Vector2int(1, 2));
            CraftDataHandler.SetItemSize(TechType.Knife, new Vector2int(1, 2));
            CraftDataHandler.SetItemSize(TechType.Flare, new Vector2int(1, 2));
            CraftDataHandler.SetItemSize(TechType.AirBladder, new Vector2int(2, 1));
            CraftDataHandler.SetItemSize(TechType.DiveReel, new Vector2int(2, 1));
            CraftDataHandler.SetItemSize(TechType.Welder, new Vector2int(2, 1));


            CraftDataHandler.SetItemSize(TechType.Scanner, new Vector2int(2, 2));


            CraftDataHandler.SetItemSize(TechType.Builder, new Vector2int(3, 2));
            CraftDataHandler.SetItemSize(TechType.LaserCutter, new Vector2int(3, 2));
            CraftDataHandler.SetItemSize(TechType.StasisRifle, new Vector2int(3, 2));
            CraftDataHandler.SetItemSize(TechType.PropulsionCannon, new Vector2int(3, 2));
            CraftDataHandler.SetItemSize(TechType.RepulsionCannon, new Vector2int(3, 2));





            // Размещаемое
            CraftDataHandler.SetItemSize(TechType.Beacon, new Vector2int(2, 2));






            //Ребеланс еды
            CraftDataHandler.SetItemSize(TechType.HangingFruit, new Vector2int(3, 2));

            CraftDataHandler.SetItemSize(TechType.AcidMushroom, new Vector2int(2, 2));
            CraftDataHandler.SetItemSize(TechType.WhiteMushroom, new Vector2int(2, 2));

            CraftDataHandler.SetItemSize(TechType.HangingFruit, new Vector2int(3, 2));





            // Материалы МОД
            CraftDataHandler.SetRecipeData(СолнечнаяЯчейкаДатабокс.Info.TechType, РецептМембраны.GetRecipeData());
            CraftDataHandler.SetRecipeData(Мембрана2.Info.TechType, РецептМембраны2.GetRecipeData());





            // Доп. Материалы МОД
            CraftDataHandler.SetRecipeData(ПлазменнаяЛинза.Info.TechType, РецептЛинзы.GetRecipeData());
            CraftDataHandler.SetRecipeData(Герметик.Info.TechType, РецептГерметик.GetRecipeData());
            CraftDataHandler.SetRecipeData(НакопительныйКонцентрат.Info.TechType, РецептКонцентрат.GetRecipeData());
            CraftDataHandler.SetRecipeData(ПространственныйПроцессор.Info.TechType, РецептПроцессор.GetRecipeData());
            CraftDataHandler.SetRecipeData(СолнечнаяЯчейка.Info.TechType, РецептЯчейка.GetRecipeData());




            // Корпоративная МОД
            CraftDataHandler.SetRecipeData(Энергоячейка2.Info.TechType, РецептЭнергоячейки2.GetRecipeData());





            // Костюм КРАБ МОД
            CraftDataHandler.SetRecipeData(МанипуляторКраба.Info.TechType, РецептМанипулятораКраба.GetRecipeData());
            CraftDataHandler.SetRecipeData(НогаКраба.Info.TechType, РецептНогаКраба.GetRecipeData());





            // Еда МОД
            CraftDataHandler.SetRecipeData(RedPeeper_MelonMousse.Info.TechType, РецептДыневыйМусс.GetRecipeData());
            CraftDataHandler.SetRecipeData(RedPeeper_AcidConcentrate.Info.TechType, РецептКислотныйКонцентрат.GetRecipeData());
            CraftDataHandler.SetRecipeData(ОбедФаберже.Info.TechType, РецептОбед.GetRecipeData());





            // Патчим и изменияем получение/количество фрагментов для чертежа
            PDAHandler.AddCustomScannerEntry(TechType.Titanium, TechType.TitaniumIngot, true, 2 );
            PDAHandler.AddCustomScannerEntry(TechType.ScrapMetal, TechType.Titanium, true, 2);

            PDAHandler.AddCustomScannerEntry(TechType.CreepvineSeedCluster, TechType.Silicone, true, 2);
            PDAHandler.AddCustomScannerEntry(TechType.Quartz, TechType.Glass, true, 2);

            PDAHandler.AddCustomScannerEntry(TechType.Copper, TechType.CopperWire, true, 2);
            PDAHandler.AddCustomScannerEntry(TechType.Silver, TechType.WiringKit, true, 2);
            PDAHandler.AddCustomScannerEntry(TechType.WiringKit, TechType.ComputerChip, true, 2);

            PDAHandler.AddCustomScannerEntry(TechType.CoralChunk, TechType.Pipe, true, 2);
            PDAHandler.AddCustomScannerEntry(TechType.CoralChunk, TechType.PipeSurfaceFloater, true, 2);

            PDAHandler.AddCustomScannerEntry(TechType.JellyPlant, TechType.FirstAidKit, true, 2);





            PDAHandler.EditFragmentScanTime(TechType.Cyclops, 16f);

            PDAHandler.EditFragmentScanTime(TechType.StasisRifle, 10f);
            PDAHandler.EditFragmentsToScan(TechType.StasisRifle, 5);
            PDAHandler.EditFragmentScanTime(TechType.Constructor, 10f);
            PDAHandler.EditFragmentsToScan(TechType.Constructor, 5);
            PDAHandler.EditFragmentScanTime(TechType.Beacon, 5f);
            PDAHandler.EditFragmentsToScan(TechType.Beacon, 4);

            PDAHandler.EditFragmentScanTime(TechType.LaserCutter, 5f);
            PDAHandler.EditFragmentsToScan(TechType.LaserCutter, 6);
            PDAHandler.EditFragmentScanTime(TechType.PropulsionCannon, 5f);
            PDAHandler.EditFragmentsToScan(TechType.PropulsionCannon, 5);



            //Лого LINER
            


            Logger.LogInfo("РЕЦЕПТЫ ЗАГРУЖЕНЫ");
        }
    }
}