using Nautilus.Crafting;

public class РецептПереборки
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Titanium, 2),
            new Ingredient(TechType.Lead, 2),
            new Ingredient(TechType.Silicone, 2),
        }
        };
    }
}