using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class RedPeeper_MelonMousse
{
  
    public static PrefabInfo Info { get; private set; }

    // Иконка
    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Fabricator", "Food", "MelonMousse.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_MelonMousse",
            "Дыневый Мусс",
            "Богатый полезными органическими веществами мусс, синтезируемый из образцов сухопутной флоры. Благодаря герметичной упаковке и синтетическим микроэлементам очень долго хранится. By Dash "
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 2)); // Размер

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Polyaniline); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            Eatable eatable = obj.EnsureComponent<Eatable>();
            BaseBioReactor.charge[Info.TechType] = 150f;
            eatable.foodValue = 40f;
            eatable.waterValue = 60f;
        };
        _prefab.SetUnlock(TechType.Melon);
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe
            
            (new RecipeData(
            new Ingredient(TechType.BulboTreePiece, 1),
            new Ingredient(TechType.PurpleRattle, 3),
            new Ingredient(TechType.DisinfectedWater, 1),
            new Ingredient(TechType.MembrainTreeSeed, 1),
            new Ingredient(TechType.Melon, 1)
            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Survival", "CookedFood")
            .WithCraftingTime(5f);
        _prefab.SetPdaGroupCategory(TechGroup.Survival, TechCategory.Water); // КПК

        _prefab.Register(); // Регистрация
    }
}
public class РецептДыневыйМусс
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.BulboTreePiece, 1),
            new Ingredient(TechType.PurpleRattle, 3),
            new Ingredient(TechType.DisinfectedWater, 1),
            new Ingredient(TechType.MembrainTreeSeed, 1),
            new Ingredient(TechType.Melon, 1)
        }
        };
    }
}
