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
            new CraftData.Ingredient(TechType.Benzene, 2),
            new CraftData.Ingredient(TechType.FiberMesh, 3),
            new CraftData.Ingredient(TechType.KooshChunk, 2)
        }
        };
    }
}
