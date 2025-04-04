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
            new CraftData.Ingredient(TechType.Titanium, 2),
            new CraftData.Ingredient(TechType.Lead, 2),
            new CraftData.Ingredient(TechType.Silicone, 2),
        }
        };
    }
}