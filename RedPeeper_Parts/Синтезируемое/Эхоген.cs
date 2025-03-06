using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Handlers;

public class ЭхоГен
{
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Synthesis", "EcholocationGene.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_EcholocationGene",
            "Эхолокационный ген",
            "Нейронные связи и клетки, позволяющие жнецу-левиафану издавать импульсы эколокации. Может использоваться в продвинутых системах акустики и радарах."
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