using Nautilus.Crafting;

public class РецептФонарика
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(МеднаяБатарейка.Info.TechType),
            new CraftData.Ingredient(TechType.Glass)
        }
        };
    }
}
