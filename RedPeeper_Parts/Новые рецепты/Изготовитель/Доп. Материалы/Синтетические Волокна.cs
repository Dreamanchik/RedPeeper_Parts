using Nautilus.Crafting;

public class РецептСинтетическихВолокон
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Benzene, 2),
            new Ingredient(TechType.FiberMesh, 3),
            new Ingredient(TechType.KooshChunk, 2)
        }
        };
    }
}
