using Nautilus.Crafting;

public class РецептСтекла
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Quartz, 2),
            new Ingredient(TechType.CoralChunk, 1),
        }
        };
    }
}
