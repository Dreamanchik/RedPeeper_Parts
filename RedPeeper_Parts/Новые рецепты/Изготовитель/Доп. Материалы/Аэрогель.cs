using Nautilus.Crafting;

public class РецептАэрогеля
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.JellyPlant, 5),
            new Ingredient(TechType.AluminumOxide, 3),
            new Ingredient(TechType.SeaCrownSeed, 2),
            new Ingredient(TechType.Quartz, 2)
        }
        };
    }
}