using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class СветоваяБатарейка : IBattery
{
    public float charge { get; set; }
    public float capacity { get; set; }

    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "CorporateTools", "LightBattery.png");

    // public static string texturePath = Path.Combine(modFolder, "Assets", "Items", "Advanced Materials", "TwoFactorProcessor_texture.png");
    // public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_LightBattery",
            "Световая батарея",
            "Использует световые отражения и тонкие пластины для рефракции света, превращая его в электричество. Энергоэффективный источник питания."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 2));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Battery); // Перфаб
        _obj.ModifyPrefab += obj =>
        {

            Battery batteryComponent = obj.GetComponent<Battery>();
            batteryComponent._capacity = 250;
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Diamond),
            new Ingredient(СолнечнаяЯчейкаДатабокс.Info.TechType, 2),
            new Ingredient(МеднаяБатарейка.Info.TechType)

            ))
            .WithStepsToFabricatorTab("Resources", "BasicMaterials")
            .WithCraftingTime(8f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics); // КПК
        _prefab.SetUnlock(СветоваяБатарейка.Info.TechType);

        //_prefab.SetUnlock(TechType.MercuryOre);
        _prefab.Register(); // Регистрация
    }

    public string GetChargeValueText()
    {
        //throw new System.NotImplementedException();
        throw new();
    }
}