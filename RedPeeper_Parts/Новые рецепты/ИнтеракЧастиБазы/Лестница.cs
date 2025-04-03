using Nautilus.Crafting;

public class РецептЛестницы
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Titanium, 2),
        }
        };
    }
}
