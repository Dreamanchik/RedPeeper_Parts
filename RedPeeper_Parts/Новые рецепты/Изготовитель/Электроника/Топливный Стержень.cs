using Nautilus.Crafting;

public class РецептСтержняРеактора
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Titanium, 3),
            new CraftData.Ingredient(TechType.Lead, 4),
            new CraftData.Ingredient(TechType.Glass, 2),
            new CraftData.Ingredient(TechType.UraniniteCrystal, 6)
        }
        };
    }
}