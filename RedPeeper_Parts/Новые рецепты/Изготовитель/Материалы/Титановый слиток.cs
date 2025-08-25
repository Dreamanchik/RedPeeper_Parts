using Nautilus.Crafting;

public class РецептТитановогоСлитка
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Titanium, 20)
        }
        };
    }
}