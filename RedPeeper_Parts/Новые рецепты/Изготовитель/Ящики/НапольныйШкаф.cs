using Nautilus.Crafting;

public class РецептНапольногоШкафа
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Titanium, 6),
            new CraftData.Ingredient(TechType.Glass, 1),
        }
        };
    }
}
