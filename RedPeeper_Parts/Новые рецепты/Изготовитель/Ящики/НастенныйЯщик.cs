using Nautilus.Crafting;

public class РецептНастенногоШкафа
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Titanium, 4),
            new CraftData.Ingredient(TechType.Copper, 1),
        }
        };
    }
}
