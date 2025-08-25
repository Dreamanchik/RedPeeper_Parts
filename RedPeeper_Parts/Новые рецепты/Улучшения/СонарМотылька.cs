using Nautilus.Crafting;
using static CraftData;

public class РецептМодуляСонара
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new Ingredient(TechType.CopperWire, 2),
                new Ingredient(TechType.Magnetite, 2),
                new Ingredient(ЭхоГен.Info.TechType, 1),
            }
        };
    }
}