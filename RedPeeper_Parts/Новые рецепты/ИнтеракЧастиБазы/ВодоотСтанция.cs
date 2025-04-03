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
            new CraftData.Ingredient(TechType.Titanium, 1),
            new CraftData.Ingredient(TechType.CopperWire, 2),
            new CraftData.Ingredient(TechType.Aerogel, 1),
            new Ingredient(АмоГель.Info.TechType, 1),
        }
        };
    }
}
