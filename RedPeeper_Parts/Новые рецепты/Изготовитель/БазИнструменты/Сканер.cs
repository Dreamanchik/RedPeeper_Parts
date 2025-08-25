using Nautilus.Crafting;

public class РецептСканера
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(МеднаяБатарейка.Info.TechType, 1),
            new Ingredient(TechType.Titanium, 2)
        }
        };
    }
}
