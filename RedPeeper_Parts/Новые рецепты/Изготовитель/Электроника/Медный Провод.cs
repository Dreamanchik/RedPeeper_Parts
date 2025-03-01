using Nautilus.Crafting;

public class РецептМедногоПровода
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.Copper, 3),
            new CraftData.Ingredient(TechType.AcidMushroom, 2),
        }
        };
    }
}