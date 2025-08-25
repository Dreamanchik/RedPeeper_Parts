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
            new Ingredient(TechType.CyclopsHullModule1, 1),
            new Ingredient(TechType.PlasteelIngot, 1),
            new Ingredient(TechType.Nickel, 4),
            new Ingredient(TechType.Gold, 6),
            new Ingredient(TechType.EnameledGlass, 1),
            new Ingredient(КомпДавл.Info.TechType, 2),
        }
        };
    }
}
