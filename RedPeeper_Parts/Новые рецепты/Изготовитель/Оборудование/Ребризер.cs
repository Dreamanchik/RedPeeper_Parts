using Nautilus.Crafting;

public class РецептРебризера
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.WiringKit, 1),
            new CraftData.Ingredient(TechType.FiberMesh, 2),
            new CraftData.Ingredient(TechType.Silicone, 2),
        }
        };
    }
}