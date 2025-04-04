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
            new CraftData.Ingredient(TechType.Titanium, 8),
            new CraftData.Ingredient(TechType.Glass, 1),
            new CraftData.Ingredient(TechType.Silicone, 1),
        }
        };
    }
}
