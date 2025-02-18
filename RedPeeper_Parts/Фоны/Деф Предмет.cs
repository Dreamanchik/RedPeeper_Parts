using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class Предмет
{

    public static PrefabInfo Info { get; private set; }
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Папка", "Папка", "Папка", "Предмет.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_Predmet",
            "Предмет",
            "Описание"
            )
            .WithSizeInInventory(new Vector2int(1, 1)) 
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        var _prefab = new CustomPrefab(Info);
        var _obj = new CloneTemplate(Info, TechType.Glass); // Префаб
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Titanium)

            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Resources", "Electronics")
            .WithCraftingTime(10f);

        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.Electronics); // КПК
        _prefab.Register(); // Регистрация
    }
}


public class РецептПредмет
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(НакопительныйКонцентрат.Info.TechType),
            new Ingredient(TechType.Titanium, 1),
        }
        };
    }
}