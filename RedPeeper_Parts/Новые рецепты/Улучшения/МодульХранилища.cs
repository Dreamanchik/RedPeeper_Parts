using Nautilus.Crafting;

public class РецептМодуляХранения
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new CraftData.Ingredient(TechType.Titanium, 4),
                new CraftData.Ingredient(TechType.Glass, 1),
                new CraftData.Ingredient(TechType.Lithium, 2)
            }
        };
    }
}
