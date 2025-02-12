using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;
using Nautilus.Extensions;

public class НакопительныйКонцентрат
{
  
    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Fabricator", "BasicMaterials", "StorageConcentrate.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_StorageConcentrate",
            "Накопительный концентрат",
            "Сложная комбинация органических веществ, способная задерживать, сохранять и передавать электрический ток. Применятся в производстве базовой электроники."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(1, 2));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Polyaniline); // Перфаб
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Titanium)

            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Resources", "BasicMaterials")
            .WithCraftingTime(5f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.BasicMaterials); // КПК

        _prefab.Register(); // Регистрация
    }
}

public class РецептКонцентрат
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.PurpleBrainCoralPiece, 2),
            new Ingredient(TechType.Copper, 2),
            new Ingredient(TechType.AcidMushroom, 4)
        }
        };
    }
}
