using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using static CraftData;
using Nautilus.Assets.Gadgets;
using Nautilus.Extensions;
using Nautilus.Handlers;
using UnityEngine;

public class Герметик
{
 
    public static PrefabInfo Info { get; private set; }

    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static string iconPath = Path.Combine(modFolder, "Assets", "Doodads", "ModifiedFabricator", "Chemical", "Sealant.png");
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_Sealant",
            "Герметик",
            "Химическое вещество, способное создавать вакуум в органических средах. Позволяет сократить расходы пространства и продлить срок хранения продуктов."
            )
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath))
            .WithSizeInInventory(new Vector2int(2, 3));

        var _prefab = new CustomPrefab(Info);

        var _obj = new CloneTemplate(Info, TechType.Polyaniline); // Перфаб
        _obj.ModifyPrefab += obj =>
        {
            BaseBioReactor.charge[Info.TechType] = 210f;
        };
        _prefab.SetUnlock(TechType.JellyPlant);
        _prefab.SetGameObject(_obj);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Titanium)

            ))
            .WithCraftingTime(5f);

        _prefab.Register(); // Регистрация
    }
}



public class РецептГерметик
{
    // Рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Salt, 1),
            new Ingredient(TechType.JellyPlant, 1),
            new Ingredient(TechType.BluePalmSeed, 2)
        }
        };
    }
}
