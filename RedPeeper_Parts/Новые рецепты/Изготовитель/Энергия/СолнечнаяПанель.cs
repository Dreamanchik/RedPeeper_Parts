using Nautilus.Crafting;
using static CraftData;

public class РецептСолнечнойПанели
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(СолнечнаяЯчейка.Info.TechType, 2),
            new Ingredient(TechType.Titanium, 2),
        }
        };
    }
}
