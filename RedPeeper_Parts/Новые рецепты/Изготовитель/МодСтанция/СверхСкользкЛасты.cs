using Nautilus.Crafting;
using static CraftData;

public class РецептСверхскользкихЛаст
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Fins, 1),
            new Ingredient(TechType.AluminumOxide, 2),
            new Ingredient(TechType.Aerogel, 1),
            new Ingredient(АмоГель.Info.TechType, 1),
        }
        };
    }
}
