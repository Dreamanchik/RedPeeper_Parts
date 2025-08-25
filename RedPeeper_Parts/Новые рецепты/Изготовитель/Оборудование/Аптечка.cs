using Nautilus.Crafting;

public class РецептАптечки
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.FiberMesh, 2),
            new Ingredient(TechType.Bleach, 1),
            new Ingredient(TechType.JellyPlant, 1),
        }
        };
    }
}
