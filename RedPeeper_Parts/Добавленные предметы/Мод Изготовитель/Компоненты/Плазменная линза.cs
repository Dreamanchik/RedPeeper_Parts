using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class ПлазменнаяЛинза
{
    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Components", "PlasmaLens.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_PlasmaLens",
            "Плазменная линза",
            "Комбинация  твёрдых, хрупких и прозрачных соединений, способная преломлять ионы поступающей электроэнергии в лазеры."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2));
            CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm);

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Aerogel); // Перфаб
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            new Ingredient(TechType.Titanium)
            ))
            .WithCraftingTime(10f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.AdvancedMaterials); // КПК
        _prefab.SetUnlock(TechType.LaserCutter);

        _prefab.Register(); // Регистрация
    }
}


public class РецептЛинзы
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(Мембрана.Info.TechType, 3),
            new Ingredient(TechType.Diamond, 5),
            new Ingredient(TechType.EnameledGlass, 2),
            new Ingredient(TechType.ComputerChip, 1)
        }
        };
    }
}