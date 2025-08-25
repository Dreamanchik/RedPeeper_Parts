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
            new Ingredient(TechType.WiringKit, 1),
            new Ingredient(TechType.FiberMesh, 2),
            new Ingredient(TechType.Silicone, 2),
        }
        };
    }
}