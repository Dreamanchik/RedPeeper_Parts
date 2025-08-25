using Nautilus.Crafting;

public class РецептБрониТранспорта
{
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,
            Ingredients =
            {
                new Ingredient(TechType.Titanium, 4),
                new Ingredient(TechType.Lead, 2),
                new Ingredient(TechType.Lithium, 2)
            }
        };
    }
}