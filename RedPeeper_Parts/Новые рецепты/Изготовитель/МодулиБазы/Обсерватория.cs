using Nautilus.Crafting;

public class РецептОбсеватории
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Titanium, 1),
            new CraftData.Ingredient(TechType.EnameledGlass, 1),
        }
        };
    }
}
