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
            new CraftData.Ingredient(TechType.CoralChunk, 3),
            new CraftData.Ingredient(TechType.Salt, 2),
        }
        };
    }
}
