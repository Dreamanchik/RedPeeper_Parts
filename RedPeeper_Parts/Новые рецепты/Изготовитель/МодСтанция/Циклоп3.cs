using Nautilus.Crafting;
using static CraftData;

public class РецептМодуляГлубиныПогруженияЦиклопа3
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.CyclopsHullModule2, 1),
            new CraftData.Ingredient(TechType.PlasteelIngot, 1),
            new CraftData.Ingredient(TechType.Kyanite, 8),
            new CraftData.Ingredient(TechType.Benzene, 2),
            new CraftData.Ingredient(TechType.Polyaniline, 2),
            new Ingredient(КомпДавл.Info.TechType, 1),
            new Ingredient(СывороткаПлоти.Info.TechType, 1),
        }
        };
    }
}
