using Nautilus.Crafting;
using static CraftData;

public class РецептВодоотчистнойСтанции
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Titanium, 1),
            new Ingredient(TechType.CopperWire, 2),
            new Ingredient(TechType.Aerogel, 1),
            new Ingredient(АмоГель.Info.TechType, 1),
        }
        };
    }
}
