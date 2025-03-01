using Nautilus.Crafting;

public class РецептСолянойКислоты
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(TechType.WhiteMushroom, 6),
            new CraftData.Ingredient(TechType.Salt, 3),
            new CraftData.Ingredient(TechType.PurpleFanSeed, 2)
        }
        };
    }
}
