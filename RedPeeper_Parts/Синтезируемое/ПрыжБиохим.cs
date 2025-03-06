using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Handlers;

public class ПрыжБиохим
{
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Synthesis", "ReferenceChemical.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_Reference_Chemical",
            "Прыжковой биохимикат",
            "C10_H16_NSO13_P3. Замкнутая среда со скоплением микроскопических бактерий и тканей, создающая механическое движение, регулирующее координацию и силу прыжка. Применяется для калибровки действий сложных гидравлических механизмов.\r\n"
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 3));
             CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.PlantWaterSeed);
             BaseBioReactor.charge[Info.TechType] = 150f;

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.BigFilteredWater);
        _prefab.SetGameObject(_obj);

        _prefab.Register(); // Рег
    }
}