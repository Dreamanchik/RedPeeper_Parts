using Nautilus.Crafting;

public class РецептКислородногоБаллона
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Titanium, 8),
            new Ingredient(TechType.Glass, 1),
            new Ingredient(TechType.Silicone, 1),
        }
        };
    }
}
