using Nautilus.Crafting;
using static CraftData;

public class РецептМодуляГлубиныПогруженияЦиклопа2
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.CyclopsHullModule1, 1),
            new CraftData.Ingredient(TechType.PlasteelIngot, 1),
            new CraftData.Ingredient(TechType.Nickel, 4),
            new CraftData.Ingredient(TechType.Gold, 6),
            new CraftData.Ingredient(TechType.EnameledGlass, 1),
            new Ingredient(КомпДавл.Info.TechType, 2),
        }
        };
    }
}
