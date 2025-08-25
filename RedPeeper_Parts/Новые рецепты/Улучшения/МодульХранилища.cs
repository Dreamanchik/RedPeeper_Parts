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
                new Ingredient(TechType.Titanium, 4),
                new Ingredient(TechType.Glass, 1),
                new Ingredient(TechType.Lithium, 2)
            }
        };
    }
}
