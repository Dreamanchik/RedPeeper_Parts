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
            new CraftData.Ingredient(TechType.Fins, 1),
            new CraftData.Ingredient(TechType.AluminumOxide, 2),
            new CraftData.Ingredient(TechType.Aerogel, 1),
            new Ingredient(АмоГель.Info.TechType, 1),
        }
        };
    }
}
