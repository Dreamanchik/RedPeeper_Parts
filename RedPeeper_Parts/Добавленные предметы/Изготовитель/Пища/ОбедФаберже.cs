using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;
using Nautilus.Handlers;

public class ОбедФаберже
{
    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "Fabricator", "Food", "FabergeLunch.png"); 
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(

            "RP_FabergeLunch",
            "Обед Фаберже",
            "Питательный обед, основанный на творениях известного ювелира - Карла Фаберже. Яйцо Кальмаро-краба посыпанное золотой посыпкой, политое соусом из шипомётов. Из мраморной дыни выжимается сок, а оставшаяся масса собирается в сахарные бриллианты. Подается вместе со стаканом сока из мраморной дыни. От Вабита"
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(3, 2));


        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Polyaniline); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            Eatable eatable = obj.EnsureComponent<Eatable>();
            eatable.foodValue = 70f;
            eatable.waterValue = 25f;

            SurvivalHandler.GiveOxygenOnConsume(Info.TechType, 10f, true);
            SurvivalHandler.GiveHealthOnConsume(Info.TechType, 10f, true);

            BaseBioReactor.charge[Info.TechType] = 200f;
        };
        _prefab.SetUnlock(TechType.CrabsquidEgg);
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(
            new Ingredient(TechType.Salt, 2),
            new Ingredient(TechType.CrabsquidEgg, 1),
            new Ingredient(TechType.Melon, 2),
            new Ingredient(TechType.Gold, 1),
            new Ingredient(TechType.SpikePlantSeed, 2)
            ))
            .WithFabricatorType(CraftTree.Type.Fabricator)
            .WithStepsToFabricatorTab("Survival", "CookedFood")
            .WithCraftingTime(10f);
        _prefab.SetPdaGroupCategory(TechGroup.Survival, TechCategory.CookedFood); // КПК

        _prefab.Register(); // Регистрация
    }
}

public class РецептОбед
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Salt, 2),
            new Ingredient(TechType.CrabsquidEgg, 1),
            new Ingredient(TechType.Melon, 2),
            new Ingredient(TechType.Gold, 1),
            new Ingredient(TechType.SpikePlantSeed, 2)
        }
        };
    }
}

