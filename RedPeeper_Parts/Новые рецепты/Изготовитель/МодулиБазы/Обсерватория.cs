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
            new Ingredient(TechType.Titanium, 1),
            new Ingredient(TechType.EnameledGlass, 1),
        }
        };
    }
}
