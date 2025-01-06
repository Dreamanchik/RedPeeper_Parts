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
            // РЕГИСТРАЦИЯ ВСЕХ ПРЕФАБОВ
            // (Название файла).Register();

            // Перфабы генерации
            DegasiBase.Register();
            DegasiBasePiece1.Register();





            // ПРЕДМЕТЫ

            // Новые предметы
            НакопительныйКонцентрат.Register();
            ПлазменнаяЛинза.Register();
            СолнечнаяЯчейка.Register();
            ПространственныйПроцессор.Register();
            Герметик.Register();
            Мембрана.Register();
            Logger.LogInfo("Новые предметы загружены");





            // Батареи




            // Части Циклопа
            ДвигательЦиклопа.Register();
            КорпусЦиклопа.Register();
            МостикЦиклопа.Register();
            Logger.LogInfo("Части Циклопа загружены");





            // Части Краба
            МанипуляторКраба.Register();
            НогаКраба.Register();
            Logger.LogInfo("Части Краба загружены");





            // Синтезируемое
            ВоздушнаяПодушка.Register();
            ВысокопрочнаяОбшивка.Register();
            КристаллическаяМембрана.Register();
            ПластичнаяСмазка.Register();
            ПрыжковойБиохимикат.Register();
            ТопливныйКонцентрат.Register();
            Logger.LogInfo("Синтезируемые материалы загружены");





            // Тестовые предметы
            RedPeeper_TrainingPeeper.Register();




            // Снаряжение




            // Регистрация ДНК передатчика
            DNASampler.Register();




            // ПОСТРОЙКИ
            // Изготовитель
            МодифицированныйИзготовитель.Patch();




            // Рецепты
            // CraftDataHandler.SetRecipeData(Techtype.(Айди предмета рецепт которого меняем), (Название файла с рецептом).GetRecipeData());
            CraftDataHandler.SetRecipeData(TechType.Cyclops, РецептЦиклопа.GetRecipeData());





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




            // Размещаемое
            CraftDataHandler.SetItemSize(TechType.Beacon, new Vector2int(2, 2));






            //Ребеланс еды
            CraftDataHandler.SetItemSize(TechType.HangingFruit, new Vector2int(3, 2));

            CraftDataHandler.SetItemSize(TechType.AcidMushroom, new Vector2int(2, 2));
            CraftDataHandler.SetItemSize(TechType.WhiteMushroom, new Vector2int(2, 2));

            CraftDataHandler.SetItemSize(TechType.HangingFruit, new Vector2int(3, 2));




            // Новая еда
            RedPeeper_MelonMousse.Register();
            RedPeeper_AcidConcentrate.Register();

            //Клеш Рояль
            Пекка.Register();
            Король1.Register();
            Король2.Register();
            АрмияСкелетов.Register();

            Logger.LogInfo("РЕЦЕПТЫ ЗАГРУЖЕНЫ");


        }
    }
}