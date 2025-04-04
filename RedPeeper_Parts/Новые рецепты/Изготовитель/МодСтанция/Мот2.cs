using Nautilus.Crafting;
using static CraftData;

public class РецептМодуляГлубиныПогруженияМотылька2
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.VehicleHullModule1, 1),
            new CraftData.Ingredient(TechType.TitaniumIngot, 1),
            new CraftData.Ingredient(TechType.Magnetite, 4),
            new CraftData.Ingredient(TechType.EnameledGlass, 1),
            new Ingredient(КомпДавл.Info.TechType, 1),
        }
        };
    }
}