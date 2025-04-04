using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;
using Nautilus.Handlers;

public class RedPeeper_AcidConcentrate
{
  
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Fabricator", "Food", "AcidConcentrate.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_AcidConcentrate",
            "Кислотный концентрат",
            "Кинцентрированная настойка, изготовленная из химически активных образцов флоры 4546B. Хорошо освежает, но травмирует пищевод. Теряет полезные свойства со времением. От Marcus_Kat"

            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 3));

        var _prefab = new CustomPrefab(Info);
        var _obj = new CloneTemplate(Info, TechType.Polyaniline); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            Eatable eatable = obj.EnsureComponent<Eatable>();
            BaseBioReactor.charge[Info.TechType] = 100f;
            eatable.waterValue = 40f;
            eatable.foodValue = -5f;

            SurvivalHandler.GiveOxygenOnConsume(Info.TechType, -30f, true);
            SurvivalHandler.GiveHealthOnConsume(Info.TechType, -49f, true);
        };
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            new Ingredient(TechType.AcidMushroom, 8),
            new Ingredient(TechType.Bleach, 1)
            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Survival", "CookedFood")
            .WithCraftingTime(5f);
        _prefab.SetPdaGroupCategory(TechGroup.Survival, TechCategory.Water); // КПК
        _prefab.SetUnlock(TechType.AcidMushroom);
        _prefab.Register(); // Регистрация
    }
}

public class РецептКислотныйКонцентрат
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.AcidMushroom, 8),
            new Ingredient(TechType.Bleach, 1)

        }
        };
    }
}
