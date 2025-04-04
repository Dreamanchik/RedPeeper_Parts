﻿using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Handlers;

public class СывороткаПлоти
{
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Synthesized", "SerumofSteelFlesh.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_SerumofSteelFlesh",
            "Сыворотка стальной плоти",
            "Крупные ткани, позволяющие рифоспину обеспечивать экосистему без время для своего здоровья. Содержит уникальные химические соединения, необходимые для синтеза прочных металлических соединений."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2));
             CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.PlantWaterSeed);
             BaseBioReactor.charge[Info.TechType] = 150f;

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.BigFilteredWater);
        _prefab.SetGameObject(_obj);

        _prefab.Register(); // Рег
    }
}