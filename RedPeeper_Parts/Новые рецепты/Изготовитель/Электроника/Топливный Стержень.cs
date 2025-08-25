using Nautilus.Crafting;

public class РецептСтержняРеактора
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Titanium, 3),
            new Ingredient(TechType.Lead, 4),
            new Ingredient(TechType.Glass, 2),
            new Ingredient(TechType.UraniniteCrystal, 6)
        }
        };
    }
}