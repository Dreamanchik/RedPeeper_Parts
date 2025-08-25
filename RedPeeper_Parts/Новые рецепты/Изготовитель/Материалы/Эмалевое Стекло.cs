using Nautilus.Crafting;

public class РецептЭмалевогоСтекла
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Glass, 2),
            new Ingredient(TechType.Lead, 3),
            new Ingredient(TechType.StalkerTooth, 1),
        }
        };
    }
}
