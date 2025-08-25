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
            new Ingredient(TechType.WhiteMushroom, 6),
            new Ingredient(TechType.Salt, 3),
            new Ingredient(TechType.PurpleFanSeed, 2)
        }
        };
    }
}
