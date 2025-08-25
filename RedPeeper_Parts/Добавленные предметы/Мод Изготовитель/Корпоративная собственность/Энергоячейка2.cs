using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using System.IO;
using System.Reflection;
using Nautilus.Utility;
using Nautilus.Crafting;
using Nautilus.Handlers;
using static CraftData;
using Nautilus.Assets.Gadgets;
using UnityEngine;
using System.Collections.Generic;

public class Энергоячейка2
{

    public static PrefabInfo Info { get; private set; }


    public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static void Register()
    {
        Info = PrefabInfo.WithTechType(
            "RP_PowerCell2",
            "Энергоячейка",
            "Переносной источник питания с высокой ёмкостью. Использует аналоговую батарею в качестве источника питания."
            )
            .WithIcon(SpriteManager.Get(TechType.PowerCell));

        var _prefab = new CustomPrefab(Info);
        _prefab.SetRecipe(new RecipeData(

            new Ingredient(TechType.Titanium, 1000)

            ))
            .WithCraftingTime(3f);
        _prefab.SetPdaGroupCategory(TechGroup.Resources, TechCategory.AdvancedMaterials); // КПК
        _prefab.SetUnlock(АналоговаяБатарея.Info.TechType);

        _prefab.Register(); // Регистрация
    }
}



public class РецептЭнергоячейки2
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        List<TechType> linkedItems = new List<TechType>()
        {
        TechType.PowerCell
        };
        return new RecipeData()
        {
            craftAmount = 0,
            LinkedItems = linkedItems,

            Ingredients =
        {
            new Ingredient(АналоговаяБатарея.Info.TechType, 1),
            new Ingredient(TechType.Silicone, 1),
        }
        };
    }
}