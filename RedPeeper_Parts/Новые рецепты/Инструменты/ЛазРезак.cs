using Nautilus.Crafting;
using static CraftData;

public class РецептЛазерногоРезака
{
    // Изменяем рецепт
    public static RecipeData GetRecipeData()
    {
        return new RecipeData()
        {
            craftAmount = 1,

            Ingredients =
        {
            new Ingredient(TechType.Silicone, 3),
            new Ingredient(TechType.Titanium, 2),
            new Ingredient(ПлазменнаяЛинза.Info.TechType, 1),
        }
        };
    }
}
