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
            new CraftData.Ingredient(TechType.Quartz, 2),
            new CraftData.Ingredient(TechType.CoralChunk, 1),
        }
        };
    }
}
