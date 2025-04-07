using Nautilus.Crafting;

public class РецептЭнергоячейки
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new CraftData.Ingredient(МеднаяБатарейка.Info.TechType, 2),
            new CraftData.Ingredient(TechType.Silicone, 1)
        }
        };
    }
}