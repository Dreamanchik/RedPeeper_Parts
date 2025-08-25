using Nautilus.Crafting;

public class РецептАнтисептика
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.CoralChunk, 3),
            new Ingredient(TechType.Salt, 2),
        }
        };
    }
}
