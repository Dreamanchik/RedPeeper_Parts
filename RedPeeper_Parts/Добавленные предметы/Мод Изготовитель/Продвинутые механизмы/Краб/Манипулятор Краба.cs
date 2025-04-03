using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;

public class МанипуляторКраба
{
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "AdvancedElectronics", "Exosuit", "PrawnArm.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RPho_PrawnArm",
            "Манипулятор костюма КРАБ",
            "Механическая конечность, сконструированная для механической работы при экстремально опасных условиях. Функциональность может быть модифицирована."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2));
        CraftDataHandler.SetBackgroundType(Info.TechType, CraftData.BackgroundType.ExosuitArm);

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, "16c60cdf-2a1c-4aff-ba9a-4c9b989cced5"); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            obj.EnsureComponent<Pickupable>();
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Titanium)

            ))
            .WithCraftingTime(20f);
        _prefab.SetPdaGroupCategory(TechGroup.Machines, TechCategory.Machines); // КПК

        _prefab.Register(); // Регистрация
    }
}





public class РецептМанипулятораКраба
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Titanium, 10),
            new Ingredient(TechType.WiringKit, 2),
            new Ingredient(TechType.Aerogel, 1),
            new Ingredient(TechType.CopperWire, 2),
        }
        };
    }
}