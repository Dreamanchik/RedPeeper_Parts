using Nautilus.Crafting;
using static CraftData;

public class РецептМодуляГлубиныПогруженияМотылька3
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.VehicleHullModule2, 1),
            new Ingredient(TechType.PlasteelIngot, 1),
            new Ingredient(TechType.Aerogel, 1),
            new Ingredient(TechType.AramidFibers, 1),
            new Ingredient(СывороткаПлоти.Info.TechType, 1),
        }
        };
    }
}