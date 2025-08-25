using Nautilus.Crafting;

public class РецептЛаст
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Silicone, 4),
        }
        };
    }
}
